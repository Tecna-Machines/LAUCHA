using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Liquidaciones.CrearLiquidacion
{
    public interface ICrearLiquidacion
    {
        Task<Result<CrearLiquidacionResponse>> Crear(CrearLiquidacionRequest req);
    }
}
