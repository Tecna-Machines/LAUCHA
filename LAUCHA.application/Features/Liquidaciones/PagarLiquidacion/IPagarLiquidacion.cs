namespace LAUCHA.application.Features.Liquidaciones.PagarLiquidacion
{
    public interface IPagarLiquidacion
    {
        Task<Result<PagoCreadoResponse>> Pagar(CrearPagoRequest req);
    }
}
