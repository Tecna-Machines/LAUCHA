namespace LAUCHA.application.Features.Liquidaciones.CrearItem
{
    public interface IFabricaItem
    {
        ItemLiquidacion Crear(CrearItemRequest item);
    }
}
