using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibos
{
    public interface IReciboMultipleRenderer
    {
        public byte[] Render(IEnumerable<GetLiquidacionByIdResponse> liquidaciones);
    }
}
