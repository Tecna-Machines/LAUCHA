using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibos
{
    internal class GetRecibosHandler : IGetRecibos
    {
        private readonly ILiquidacionRepository _liquidaciones;
        private readonly IGetLiquidacionById _getLiquidacion;
        private readonly IReciboMultipleRenderer _recibos;

        public GetRecibosHandler(ILiquidacionRepository liquidaciones,
                                 IGetLiquidacionById getLiquidacion,
                                 IReciboMultipleRenderer recibos)
        {
            _liquidaciones = liquidaciones;
            _getLiquidacion = getLiquidacion;
            _recibos = recibos;
        }

        public async Task<Result<GetRecibosResponse>> Get(GetRecibosRequest req)
        {
            var liquidaciones = await _liquidaciones.GetByQuincena(req.Quincena, req.Mes, req.Anio);

            List<GetLiquidacionByIdResponse> liquidacionesResponse = new();

            foreach (var liq in liquidaciones)
            {
                var liquidacion = await _getLiquidacion.Get(liq.Codigo);

                liquidacionesResponse.Add(liquidacion.Value);
            }

            var recibo = await _recibos.Render(liquidacionesResponse);

            var response = new GetRecibosResponse(
                                "recibo.pdf",
                                "application/pdf",
                                recibo
                                );

            return Result.Success(response);
        }


    }
}
