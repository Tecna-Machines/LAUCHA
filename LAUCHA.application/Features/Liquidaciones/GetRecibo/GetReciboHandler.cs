
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibo
{
    internal class GetReciboHandler : IGetRecibo
    {
        private readonly IGetEmpleadoAsistencias _asistenciasEmpleado;
        private readonly IGetLiquidacionById _getLiquidacion;
        private readonly IReciboRenderer _renderer;

        public GetReciboHandler(IGetLiquidacionById getLiquidacion, IReciboRenderer renderer, IGetEmpleadoAsistencias asistenciasEmpleado)
        {
            _getLiquidacion = getLiquidacion;
            _renderer = renderer;
            _asistenciasEmpleado = asistenciasEmpleado;
        }

        public async Task<Result<GetReciboLiquidacionResponse>> Get(GetReciboLiquidacionRequest req)
        {
            var liquidacionResult = await _getLiquidacion.Get(req.Id);

            if (liquidacionResult.IsFailure)
                return Result.Failure<GetReciboLiquidacionResponse>(liquidacionResult.Error);

            var asistencia = await GetAsistencias(liquidacionResult.Value);


            if (asistencia.IsFailure)
                return Result.Failure<GetReciboLiquidacionResponse>(asistencia.Error);


            var recibo = _renderer.Render(liquidacionResult.Value,asistencia.Value);

            var response = new GetReciboLiquidacionResponse(
                                "recibo.pdf",
                                "application/pdf",
                                recibo
                                );

            return Result.Success(response);
        }

        public async Task<Result<GetEmpleadoAsistenciasResponse>> GetAsistencias(GetLiquidacionByIdResponse liq)
        {
            DateTime inicioMes = new DateTime(liq.Quincena.Anio,liq.Quincena.Mes,1);
            DateTime finMes = new DateTime(liq.Quincena.Anio,liq.Quincena.Mes,DateTime.DaysInMonth(liq.Quincena.Anio,liq.Quincena.Mes));

            var resultAsistencia = await _asistenciasEmpleado.GetAsistencias(new GetEmpleadoAsistenciaRequest(liq.Empleado.Dni,inicioMes,finMes));

            return resultAsistencia;
        }

        
    }
}
