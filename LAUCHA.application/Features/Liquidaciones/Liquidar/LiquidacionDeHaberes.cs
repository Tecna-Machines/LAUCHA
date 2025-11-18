using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class LiquidacionDeHaberes : ILiquidacionDeHaberes
    {
        private Liquidacion _liquidacion;
        private Acuerdo _acuerdo;
        private IList<ItemLiquidacion> _items;

        private readonly ICalculadoraDeSueldos _calculadoraSueldo;
        private readonly ICalculadoraRetenciones _calculadoraRetenciones;

        public LiquidacionDeHaberes(ICalculadoraDeSueldos calculadoraSueldo, ICalculadoraRetenciones calculadoraRetenciones)
        {
            _calculadoraSueldo = calculadoraSueldo;
            _items = new List<ItemLiquidacion>();

            _liquidacion = new();
            _acuerdo = new();
            _calculadoraRetenciones = calculadoraRetenciones;
        }

        public void Liquidar(Liquidacion liquidacion, Acuerdo acuerdo)
        {
            if (liquidacion.CodigoAcuerdo != acuerdo.Codigo)
                throw new InvalidOperationException("acuerdo.no.valido");

            _liquidacion = liquidacion;
            _acuerdo = acuerdo;


            CalcularSueldo();
            CalcularAntiguedad();
            CalcularRetenciones();

            _liquidacion.AplicarCalculosAutomaticos(_items);
        }


        private void CalcularSueldo()
        {
            var itemsSueldo = _calculadoraSueldo
                                .CalcularItemsSueldo(_liquidacion, _acuerdo);

            foreach (var item in itemsSueldo)
            {
                _items.Add(item);
            }
        }

        private void CalcularAntiguedad()
        {
            int anios = _acuerdo.Empleado.GetAntiguedad();

            decimal totalRemunerativo = _liquidacion.CalcularTotalRemunerativoBlanco();
            decimal valorAntiguedad = (anios / 100) * totalRemunerativo;

            var itemAntiguedad = ItemLiquidacion.CrearRemunerativo("antiguedad", valorAntiguedad);

            _items.Add(itemAntiguedad);
        }

        private void CalcularRetenciones()
        {
            var itemsRetenciones = _calculadoraRetenciones.CalcularItemsRetenciones(_liquidacion, _acuerdo);

            foreach (var item in itemsRetenciones)
            {
                _items.Add(item);
            }
        }

    }
}
