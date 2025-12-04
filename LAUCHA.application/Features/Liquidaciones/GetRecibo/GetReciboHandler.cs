
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibo
{
    internal class GetReciboHandler : IGetRecibo
    {
        private readonly IGetLiquidacionById _getLiquidacion;
        private readonly IReciboRenderer _renderer;

        public GetReciboHandler(IGetLiquidacionById getLiquidacion, IReciboRenderer renderer)
        {
            _getLiquidacion = getLiquidacion;
            _renderer = renderer;
        }

        public async Task<Result<GetReciboLiquidacionResponse>> Get(GetReciboLiquidacionRequest req)
        {
            var liquidacionResult = await _getLiquidacion.Get(req.Id);

            if (liquidacionResult.IsFailure)
                return Result.Failure<GetReciboLiquidacionResponse>(liquidacionResult.Error);

            var recibo = _renderer.Render(liquidacionResult.Value);

            var response = new GetReciboLiquidacionResponse(
                                "recibo.pdf",
                                "application/pdf",
                                recibo
                                );

            return Result.Success(response);
        }
    }
}
