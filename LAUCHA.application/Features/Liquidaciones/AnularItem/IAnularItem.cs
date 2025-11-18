using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Liquidaciones.AnularItem
{
    public interface IAnularItem
    {
        Task<Result<AnularItemResponse>> Anular(string codigoLiquidacion, int NroItem);
    }
}
