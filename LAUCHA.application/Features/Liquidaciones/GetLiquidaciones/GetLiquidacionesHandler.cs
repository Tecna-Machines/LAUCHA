using LAUCHA.application.Common.ResultResponse;
using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.application.Features.Liquidaciones.GetLiquidaciones
{
    internal class GetLiquidacionesHandler : IGetLiquidaciones
    {
        private readonly ILiquidacionRepository _liquidaciones;
        private readonly IEmpleadoRepository _empleados;

        public GetLiquidacionesHandler(ILiquidacionRepository liquidaciones, IEmpleadoRepository empleados)
        {
            _liquidaciones = liquidaciones;
            _empleados = empleados;
        }

        public async Task<Result<GetLiquidacionesResponse>> Get(GetLiquidacionesRequest req)
        {
            var liquidaciones = await _liquidaciones.GetByQuincena(req.Quincena,req.Mes, req.Anio);

            var liquidacionesMap = await MapLiquidaciones(liquidaciones);


            var response = new GetLiquidacionesResponse(liquidacionesMap.Count(),
                                                       liquidacionesMap);

            return Result.Success(response);
        }

        private async Task<IEnumerable<LiquidacionResumenResponse>> MapLiquidaciones(IEnumerable<Liquidacion> liquidaciones)
        {
            List<LiquidacionResumenResponse> liquidacionesResumidas = new();
            foreach (var liq in liquidaciones)
            {
                var emp = await _empleados.GetByDni(liq.DniEmpleado);

                var response = new LiquidacionResumenResponse(liq.Codigo,
                                                              liq.Concepto,
                                                              liq.DniEmpleado,
                                                              emp!.GetFullName(),
                                                              liq.FechaCreacion,
                                                              liq.FechaSello,
                                                              liq.EstaSellada());

                liquidacionesResumidas.Add(response);
            }

            return liquidacionesResumidas;
        }
    }
}
