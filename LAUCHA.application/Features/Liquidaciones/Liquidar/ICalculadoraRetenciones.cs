namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public interface ICalculadoraRetenciones
    {
        public ICollection<ItemLiquidacion> CalcularItemsRetenciones(Liquidacion liq, Acuerdo acu);
    }
}
