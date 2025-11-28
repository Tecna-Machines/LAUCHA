namespace LAUCHA.application.Features.Liquidaciones.GetLiquidacionById
{
    public interface IGetLiquidacionById
    {
        Task<Result<GetLiquidacionByIdResponse>> Get(string codigo);
    }
}
