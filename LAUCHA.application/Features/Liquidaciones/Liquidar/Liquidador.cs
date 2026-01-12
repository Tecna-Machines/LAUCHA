namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class Liquidador : ILiquidadorDeHaberes
    {
        private Liquidacion _liquidacion;
        private Acuerdo _acuerdo;
        private IList<ItemLiquidacion> _items;
        private CalculadoraDescuentos _calculadoraDescuentos;

        private decimal _montoBaseRetenciones;
        private decimal _montoBaseAntiguedad;

        private decimal _netoEnBlanco;
        public Liquidador(CalculadoraDescuentos calculadoraDescuentos)
        {
            _items = new List<ItemLiquidacion>();

            _liquidacion = new();
            _acuerdo = new();
            _calculadoraDescuentos = calculadoraDescuentos;
        }

        public void Liquidar(Liquidacion liquidacion, Acuerdo acuerdo)
        {
            if (liquidacion.CodigoAcuerdo != acuerdo.Codigo)
                throw new InvalidOperationException("acuerdo.no.valido");

            _montoBaseRetenciones = 0;
            _liquidacion = liquidacion;
            _acuerdo = acuerdo;


            AgregarSueldos();
            AgregarAdicionales();
            AgregarAntiguedad();
            AgregarRetenciones();
            DescontarCreditosYAdelantos();

            _liquidacion.AplicarItemsAutomaticos(_items);
        }

        public void AgregarSueldos()
        {
            var sueldoEnBlanco = CalculadoraSueldoBlanco.Calcular(_liquidacion, _acuerdo);

            _montoBaseAntiguedad = sueldoEnBlanco.Monto;
            _netoEnBlanco += sueldoEnBlanco.Monto;
            _montoBaseRetenciones += sueldoEnBlanco.Monto;


            var sueldoEnNegro = CalculadoraSueldoNegro.Calcular(_liquidacion, _acuerdo);

            var itemsEnBlancoPreexistentes = _liquidacion.GetAllItems()
                                                        .Where(it => it.Tipo == TipoItemLiquidacion.Remunerativo
                                                        && it.EsAutomatico == false && it.EsEnBlanco && it.Estado != EstadoItemLiquidacion.ANULADO);

            foreach (var item in itemsEnBlancoPreexistentes)
            {
                _montoBaseRetenciones += item.Monto;
                _netoEnBlanco += item.Monto;
            }

            _items.Add(sueldoEnBlanco);
            _items.Add(sueldoEnNegro);
        }

        public void AgregarAdicionales()
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

            decimal valorAntiguedad = (anios * _montoBaseAntiguedad) / 100m;

            var itemAntiguedad = ItemLiquidacion.CrearRemunerativo("antiguedad", valorAntiguedad);
            _items.Add(itemAntiguedad);

            _montoBaseRetenciones += valorAntiguedad;
            _netoEnBlanco += valorAntiguedad;
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

                var retencionesNueva = ItemLiquidacion.CrearRetencion(retencion.Concepto, monto);

                sumaRetenciones += monto;

                _items.Add(retencionesNueva);
            }

            var retencionItemNegro = ItemLiquidacion.CrearDescuentoEnNegro("retencion blanco", sumaRetenciones);

            var itemNetoBlanco = ItemLiquidacion.CrearDescuentoEnNegro("deposito", _netoEnBlanco - sumaRetenciones);

            _items.Add(itemNetoBlanco);
            _items.Add(retencionItemNegro);
        }

        private IEnumerable<RetencionAcuerdo> GetRetencionesParaLiquidar()
        {
            if (_acuerdo.TipoSueldo == TipoSueldo.QuincenalFijo || _acuerdo.TipoSueldo == TipoSueldo.QuincenalHora)
            {
                if (_liquidacion.EsPrimeraQuincena())
                {
                    return _acuerdo.GetRetencionesPrimeraQuincena();
                }

                return _acuerdo.GetRetencionesSegundaQuincena();
            }

            return _acuerdo.GetRetenciones();
        }

        private void DescontarCreditosYAdelantos()
        {
            var descuentos = _calculadoraDescuentos.GenerarItemsDescuentos(_liquidacion);

            foreach (var desc in descuentos)
            {
                _items.Add(desc);
            }
        }




    }
}
