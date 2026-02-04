using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibos
{
    public interface IReciboMultipleRenderer
    {
        public Task<byte[]> Render(IEnumerable<GetLiquidacionByIdResponse> liquidaciones);
    }
}
