using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Liquidaciones.GetLiquidaciones
{
    public interface IGetLiquidaciones
    {
        Task<Result<GetLiquidacionesResponse>> Get(GetLiquidacionesRequest req);
    }
}
