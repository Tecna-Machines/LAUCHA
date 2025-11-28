namespace LAUCHA.application.Features.Liquidaciones.CrearItem
{
    public interface ICrearItem
    {
        Task<Result<CrearItemResponse>> Crear(string codigoLiquidacion, CrearItemRequest req);
    }
}
