using LAUCHA.application.Helpers;
using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class LiquidacionDeHaberes : ILiquidacionDeHaberes
    {
        private Liquidacion _liquidacion;
        private Acuerdo _acuerdo;
        private IList<ItemLiquidacion> _items;


        private decimal _montoBaseRetenciones;
        private decimal _montoBaseAntiguedad;

        private decimal _netoEnBlanco;
        public LiquidacionDeHaberes()
        {
            _items = new List<ItemLiquidacion>();

            _liquidacion = new();
            _acuerdo = new();
        }

        public void Liquidar(Liquidacion liquidacion, Acuerdo acuerdo)
        {
            if (liquidacion.CodigoAcuerdo != acuerdo.Codigo)
                throw new InvalidOperationException("acuerdo.no.valido");

            _montoBaseRetenciones = 0;
            _liquidacion = liquidacion;
            _acuerdo = acuerdo;


            CalcularSueldo();
            CalcularAdicionales();
            CalcularAntiguedad();
            CalcularRetenciones();

            _liquidacion.AplicarCalculosAutomaticos(_items);
        }

        public void CalcularSueldo()
        {
            var itemSueldoBlanco = CalculadoraSueldoBlanco.Calcular(_liquidacion, _acuerdo);

            _netoEnBlanco += itemSueldoBlanco.Monto;
            _montoBaseRetenciones += itemSueldoBlanco.Monto;

            _montoBaseAntiguedad = itemSueldoBlanco.Monto;

            var itemSueldoNegro = CalculadoraSueldoNegro.Calcular(_liquidacion, _acuerdo);

            var itemsExistentesEnBlanco = _liquidacion.GetItems()
                                                        .Where(it => it.Tipo == TipoItemLiquidacion.Remunerativo
                                                        && it.EsAutomatico == false && it.EsEnBlanco);

            foreach (var item in itemsExistentesEnBlanco)
            {
                _montoBaseRetenciones += item.Monto;
                _netoEnBlanco += item.Monto;
            }

            _items.Add(itemSueldoBlanco);
            _items.Add(itemSueldoNegro);
        }

        public void CalcularAdicionales()
        {
            var adicionales = _acuerdo.GetAdicionales();

            foreach (var adi in adicionales)
            {
                var item = ItemLiquidacion.CrearRemunerativoEnNegro(adi.Concepto, adi.Monto);

                _items.Add(item);
            }

        }

        private void CalcularAntiguedad()
        {
            decimal anios = _acuerdo.Empleado.GetAntiguedad();

            decimal valorAntiguedad = (anios * _montoBaseAntiguedad) / 100m;

            var itemAntiguedad = ItemLiquidacion.CrearRemunerativo("antiguedad", valorAntiguedad);
            _items.Add(itemAntiguedad);

            _montoBaseRetenciones += valorAntiguedad;
            _netoEnBlanco += valorAntiguedad;
        }

        public void CalcularRetenciones()
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




    }
}
