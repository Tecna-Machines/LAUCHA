using LAUCHA.domain.Services.Sueldo;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class Liquidador : ILiquidador
    {
        private Liquidacion _liquidacion;
        private Acuerdo _acuerdo;
        private ICollection<ItemLiquidacion> _items;
        private AcreditadorDeCreditos _acreditador;
        private CobradorDeCuotas _cobradorCuotas;
        private CalculadoraHorasEspeciales _calculadoraHsExtra;

        private ISueldoService _sueldoService;

        private decimal _brutoOficial;
        private decimal _baseCalculoAntiguedad;
        private decimal _netoEnBlanco;

        private decimal _brutoRemunerativo;


        public Liquidador(AcreditadorDeCreditos calculadoraDescuentos,
                          CobradorDeCuotas cobradorCuotas,
                          CalculadoraHorasEspeciales calculadoraHsExtra,
                          ISueldoService sueldoService)
        {
            _items = new List<ItemLiquidacion>();

            _liquidacion = new();
            _acuerdo = new();
            _acreditador = calculadoraDescuentos;
            _cobradorCuotas = cobradorCuotas;
            _calculadoraHsExtra = calculadoraHsExtra;
            _sueldoService = sueldoService;
        }

        public async Task RecalcularLiquidacion(Liquidacion liquidacion, Acuerdo acuerdo)
        {
            if (liquidacion.CodigoAcuerdo != acuerdo.Codigo)
                throw new InvalidOperationException("acuerdo.no.valido");

            _brutoOficial = 0;
            _liquidacion = liquidacion;
            _acuerdo = acuerdo;


            await AgregarSueldos();
            AgregarItemsDeAdicionales();
            await AgregarHorasFeriadoOficial();
            AgregarAntiguedad();
            AgregarRetenciones();

            await AgregarCreditosYAdelantos();
            await AgregarItemDescuentoDeCuotas();

            await AgregarHorasExtra();

            _liquidacion.ReemplazarItemsAutomaticos(_items);
        }

        public async Task AgregarSueldos()
        {
            var itemSueldoOficial = await _sueldoService.ComputarOficial(_liquidacion);
            var itemSueldoIntenro = _sueldoService.ComputarInterno(_liquidacion);

            _baseCalculoAntiguedad = itemSueldoOficial.Monto;
            _netoEnBlanco += itemSueldoOficial.Monto;
            _brutoOficial += itemSueldoOficial.Monto;
            _brutoRemunerativo += itemSueldoOficial.Monto;



            var montoItemsOficialGeneradosManualmente = _liquidacion.GetAllItems()
                                                        .Where(it => it.Tipo == TipoItemLiquidacion.Remunerativo
                                                        && it.generadoPorUsuario != false && it.EsEnBlanco && it.Estado != EstadoItemLiquidacion.ANULADO)
                                                        .Sum(it => it.Monto);


            _brutoOficial += montoItemsOficialGeneradosManualmente;
            _netoEnBlanco += montoItemsOficialGeneradosManualmente;

            _items.Add(itemSueldoOficial);
            _items.Add(itemSueldoIntenro);
        }

        public void AgregarItemsDeAdicionales()
        {
            if (_liquidacion.EsPrimeraQuincena())
            {
                return;
            }

            var adicionales = _acuerdo.GetAdicionales();

            foreach (var adi in adicionales)
            {
                var item = ItemLiquidacion.CrearRemunerativoInterno(adi.Concepto, adi.Monto);

                _items.Add(item);
            }

        }

        private async Task AgregarHorasFeriadoOficial()
        {
            var itemsHsFeriadosOficial = await _calculadoraHsExtra
                .GenerarItemHorasFeriadoOficial(_liquidacion);

            if (!_acuerdo.PuedeHacerHorasExtra())
            {
                return;
            }

            _baseCalculoAntiguedad += itemsHsFeriadosOficial.Monto;
            _brutoOficial += itemsHsFeriadosOficial.Monto;
            _netoEnBlanco += itemsHsFeriadosOficial.Monto;
            _brutoRemunerativo += itemsHsFeriadosOficial.Monto;


            _items.Add(itemsHsFeriadosOficial);
        }

        private void AgregarAntiguedad()
        {
            decimal anios = _acuerdo.Empleado.GetAntiguedadEnAnios();
            decimal montoAntiguedad = (anios * _baseCalculoAntiguedad) / 100m;

            var itemAntiguedad = ItemLiquidacion
                                .CrearRemunerativo($"antiguedad ({anios})", montoAntiguedad);

            _items.Add(itemAntiguedad);

            _brutoOficial += montoAntiguedad;
            _netoEnBlanco += montoAntiguedad;
            _brutoRemunerativo += montoAntiguedad;
        }

        public void AgregarRetenciones()
        {
            decimal sumaRetenciones = 0;

            var retenciones = GetRetencionesParaLiquidar();


            foreach (var retencion in retenciones)
            {
                decimal monto;

                if (retencion.EsPorcentual)
                {
                    monto = CalculadorDePorcentaje.GetMontoSegunPorcentaje(retencion.Unidades, _brutoOficial);
                }
                else
                {
                    monto = retencion.Unidades;
                }

                var retencionesNueva = ItemLiquidacion.CrearRetencion($"{retencion.Concepto} ({retencion.Unidades.ToString("N2")})", monto);

                //TODO: estp probablemente este mal , va esta rremal
                string codigoObraSocial = "0910";

                if (retencion.CodigoRetencion == codigoObraSocial)
                {
                    var obraSocialRetencion = CalculoEspecialObraSocial();
                    sumaRetenciones += obraSocialRetencion.Monto;
                    _items.Add(obraSocialRetencion);

                }
                else
                {
                    sumaRetenciones += monto;
                    _items.Add(retencionesNueva);
                }

            }

            var itemRetencion = ItemLiquidacion.CrearDescuentoInterno("retenciones", sumaRetenciones);
            var itemDeposito = ItemLiquidacion.CrearDescuentoInterno("deposito", _netoEnBlanco - sumaRetenciones);

            _items.Add(itemDeposito);
            _items.Add(itemRetencion);
        }

        //TODO: es muy probable que esto no vaya aqui
        private IEnumerable<RetencionAcuerdo> GetRetencionesParaLiquidar()
        {
            if (_acuerdo.TipoSueldo == TipoSueldo.QUINCENAL_FIJO || _acuerdo.TipoSueldo == TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA)
            {
                if (_liquidacion.EsPrimeraQuincena())
                {
                    return _acuerdo.GetRetencionesPrimeraQuincena();
                }

                return _acuerdo.GetRetencionesSegundaQuincena();
            }

            return _acuerdo.GetRetenciones();
        }

        private async Task AgregarCreditosYAdelantos()
        {
            var acreditaciones = await _acreditador.GenerarItemsDeAcreditacion(_liquidacion);

            foreach (var item in acreditaciones)
            {
                _items.Add(item);
            }
        }

        private async Task AgregarItemDescuentoDeCuotas()
        {
            var itemsCuotas = await _cobradorCuotas.GenerarItemsDeCuota(_liquidacion);

            foreach (var item in itemsCuotas)
            {
                _items.Add(item);
            }
        }

        private async Task AgregarHorasExtra()
        {
            var itemHsExtra = await _calculadoraHsExtra
                    .GenerarItemHorasExtra(_liquidacion);

            var itemHsDoble = await _calculadoraHsExtra
                        .GenerarItemHorasDoble(_liquidacion);

            if (!_acuerdo.PuedeHacerHorasExtra())
            {
                itemHsExtra.Monto = 0;
                itemHsDoble.Monto = 0;
            }

            _items.Add(itemHsExtra);
            _items.Add(itemHsDoble);
        }

        private ItemLiquidacion CalculoEspecialObraSocial()
        {
            const decimal horasMensualesJornadaCompleta = 200m;
            const decimal porcentajeObraSocial = 0.03m;

            decimal baseObraSocial;

            if (_liquidacion.Acuerdo.Jornada == domain.Enums.Jornada.COMPLETA)
            {
                baseObraSocial = _brutoRemunerativo;
            }
            else if (_liquidacion.Acuerdo.EsMensual())
            {
                /*
                 * ValorSueldoOJornal debe representar aquí el sueldo
                 * mensual pactado de media jornada.
                 */
                decimal sueldoCompleto =
                    _liquidacion.Acuerdo.ValorSueldoOJornal * 2m;

                decimal antiguedad =
                    _liquidacion.Acuerdo.Empleado.GetAntiguedadEnAnios() / 100m;

                baseObraSocial =
                    sueldoCompleto * (1m + antiguedad);
            }
            else
            {
                decimal horasBasePeriodo =
                    horasMensualesJornadaCompleta / 2m;

                decimal valorHoraConvenio =
                    _liquidacion.Acuerdo.ValorSueldoOJornal;

                decimal antiguedad =
                    _liquidacion.Acuerdo.Empleado.GetAntiguedadEnAnios() / 100m;

                baseObraSocial =
                    valorHoraConvenio
                    * horasBasePeriodo
                    * (1m + antiguedad);
            }

            decimal descuentoObraSocial = Math.Round(
                baseObraSocial * porcentajeObraSocial,
                2,
                MidpointRounding.AwayFromZero);

            return ItemLiquidacion.CrearRetencion(
                "Obra Social 3%",
                descuentoObraSocial);
        }

    }
}