namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class Liquidador : ILiquidador
    {
        private Liquidacion _liquidacion;
        private Acuerdo _acuerdo;
        private ICollection<ItemLiquidacion> _items;
        private AcreditadorDeCreditos _acreditador;
        private CobradorDeCuotas _cobradorCuotas;
        private CalculadorasHorasExtra _calculadoraHsExtra;

        private decimal _montoBaseRetenciones;
        private decimal _montoBaseAntiguedad;
        private decimal _netoEnBlanco;


        public Liquidador(AcreditadorDeCreditos calculadoraDescuentos,
                          CobradorDeCuotas cobradorCuotas,
                          CalculadorasHorasExtra calculadoraHsExtra)
        {
            _items = new List<ItemLiquidacion>();

            _liquidacion = new();
            _acuerdo = new();
            _acreditador = calculadoraDescuentos;
            _cobradorCuotas = cobradorCuotas;
            _calculadoraHsExtra = calculadoraHsExtra;
        }

        public async Task Liquidar(Liquidacion liquidacion, Acuerdo acuerdo)
        {
            if (liquidacion.CodigoAcuerdo != acuerdo.Codigo)
                throw new InvalidOperationException("acuerdo.no.valido");

            _montoBaseRetenciones = 0;
            _liquidacion = liquidacion;
            _acuerdo = acuerdo;


            AgregarSueldos();
            AgregarItemsDeAdicionales();
            AgregarAntiguedad();
            AgregarRetenciones();

            await AgregarCreditosYAdelantos();
            await AgregarItemDescuentoDeCuotas();

            await AgregarHorasExtra();

            _liquidacion.ReemplazarItemsAutomaticos(_items);
        }

        public void AgregarSueldos()
        {
            var sueldoEnBlanco = GeneradorSueldoEnBlanco.Generar(_liquidacion, _acuerdo);

            _montoBaseAntiguedad = sueldoEnBlanco.Monto;
            _netoEnBlanco += sueldoEnBlanco.Monto;
            _montoBaseRetenciones += sueldoEnBlanco.Monto;


            var sueldoEnNegro = GeneradorSueldoEnNegro.Generar(_liquidacion, _acuerdo);

            var itemsEnBlancoPreexistentes = _liquidacion.GetAllItems()
                                                        .Where(it => it.Tipo == TipoItemLiquidacion.Remunerativo
                                                        && it.generadoPorUsuario != false && it.EsEnBlanco && it.Estado != EstadoItemLiquidacion.ANULADO);

            decimal totalBlancoPreexistente = itemsEnBlancoPreexistentes.Sum(it => it.Monto);

            _montoBaseRetenciones += totalBlancoPreexistente;
            _netoEnBlanco += totalBlancoPreexistente;

            _items.Add(sueldoEnBlanco);
            _items.Add(sueldoEnNegro);
        }

        public void AgregarItemsDeAdicionales()
        {
            var adicionales = _acuerdo.GetAdicionales();

            foreach (var adi in adicionales)
            {
                var item = ItemLiquidacion.CrearRemunerativoEnNegro(adi.Concepto, adi.Monto);

                _items.Add(item);
            }

        }

        private void AgregarAntiguedad()
        {
            decimal anios = _acuerdo.Empleado.GetAntiguedad();

            decimal montoAntiguedad = (anios * _montoBaseAntiguedad) / 100m;

            var itemAntiguedad = ItemLiquidacion.CrearRemunerativo($"antiguedad ({anios})", montoAntiguedad);

            _items.Add(itemAntiguedad);

            _montoBaseRetenciones += montoAntiguedad;
            _netoEnBlanco += montoAntiguedad;
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
                    monto = CalculadorDePorcentaje.GetMontoSegunPorcentaje(retencion.Unidades, _montoBaseRetenciones);
                }
                else
                {
                    monto = retencion.Unidades;
                }

                var retencionesNueva = ItemLiquidacion.CrearRetencion($"{retencion.Concepto} ({retencion.Unidades.ToString("N2")})", monto);

                sumaRetenciones += monto;

                _items.Add(retencionesNueva);
            }

            var retencionItemNegro = ItemLiquidacion.CrearDescuentoEnNegro("retenciones oficial", sumaRetenciones);

            var itemNetoBlanco = ItemLiquidacion.CrearDescuentoEnNegro("deposito", _netoEnBlanco - sumaRetenciones);

            _items.Add(itemNetoBlanco);
            _items.Add(retencionItemNegro);
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
            if (!_acuerdo.PuedeHacerHorasExtra())
            {
                return;
            }

            var itemHsExtra = await _calculadoraHsExtra
                                .GenerarItemHorasExtra(_liquidacion);

            _items.Add(itemHsExtra);
        }

    }
}