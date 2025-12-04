namespace LAUCHA.application.Features.Liquidaciones.GetRecibo
{
    public interface IGetRecibo
    {
        Task<Result<GetReciboLiquidacionResponse>> Get(GetReciboLiquidacionRequest req);
    }
}
