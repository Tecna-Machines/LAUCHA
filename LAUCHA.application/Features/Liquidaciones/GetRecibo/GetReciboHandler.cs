
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Feriados.GetFeriadoMes;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;

namespace LAUCHA.application.Features.Liquidaciones.GetRecibo
{
    internal class GetReciboHandler : IGetRecibo
    {
        private readonly IGetEmpleadoAsistencias _asistenciasEmpleado;
        private readonly IGetFeriadosMes _feriadosMes;
        private readonly IGetLiquidacionById _getLiquidacion;
        private readonly IReciboRenderer _renderer;

        public GetReciboHandler(IGetLiquidacionById getLiquidacion,
                                IReciboRenderer renderer,
                                IGetEmpleadoAsistencias asistenciasEmpleado,
                                IGetFeriadosMes feriados)
        {
            _getLiquidacion = getLiquidacion;
            _renderer = renderer;
            _asistenciasEmpleado = asistenciasEmpleado;
            _feriadosMes = feriados;
        }

        public async Task<Result<GetReciboLiquidacionResponse>> Get(GetReciboLiquidacionRequest req)
        {
            var liquidacionResult = await _getLiquidacion.Get(req.Id);

            if (liquidacionResult.IsFailure)
                return Result.Failure<GetReciboLiquidacionResponse>(liquidacionResult.Error);

            var asistenciaResult = await GetAsistencias(liquidacionResult.Value);


            if (asistenciaResult.IsFailure)
                return Result.Failure<GetReciboLiquidacionResponse>(asistenciaResult.Error);

            var feriadosResult = await _feriadosMes.Get(liquidacionResult.Value.Quincena.Mes,liquidacionResult.Value.Quincena.Anio);

            if(feriadosResult.IsFailure)
                return Result.Failure<GetReciboLiquidacionResponse>(feriadosResult.Error);


            GetEmpleadoAsistenciasResponse asistencias = asistenciaResult.Value;
            GetLiquidacionByIdResponse liquidacion = liquidacionResult.Value;
            GetFeriadosMesResponse feriados = feriadosResult.Value;

            var reciboData = new ReciboRequest(liquidacion,asistencias,feriados);

            var recibo = _renderer.Render(reciboData);

            var response = new GetReciboLiquidacionResponse(
                                "recibo.pdf",
                                "application/pdf",
                                recibo
                                );

            return Result.Success(response);
        }

        public async Task<Result<GetEmpleadoAsistenciasResponse>> GetAsistencias(GetLiquidacionByIdResponse liq)
        {
            DateTime inicioMes = new DateTime(liq.Quincena.Anio, liq.Quincena.Mes, 1);
            DateTime finMes = new DateTime(liq.Quincena.Anio, liq.Quincena.Mes, DateTime.DaysInMonth(liq.Quincena.Anio, liq.Quincena.Mes));

            var resultAsistencia = await _asistenciasEmpleado.GetAsistencias(new GetEmpleadoAsistenciaRequest(liq.Empleado.Dni, inicioMes, finMes));

            return resultAsistencia;
        }

    }
}
