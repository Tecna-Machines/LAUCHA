using LAUCHA.domain.Entities.Asistencias;

namespace LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias
{
    internal class GetEmpleadoAsistenciasHandler : IGetEmpleadoAsistencias
    {
        private IEmpleadoRepository _empleados;
        private IAsistenciasSource _asistencias;

        public GetEmpleadoAsistenciasHandler(IAsistenciasSource asistencias, IEmpleadoRepository empleados)
        {
            _asistencias = asistencias;
            _empleados = empleados;
        }

        public async Task<Result<GetEmpleadoAsistenciasResponse>> GetAsistencias(GetEmpleadoAsistenciaRequest req)
        {
            var empleado = await _empleados.GetByDni(req.Dni);

            if (empleado is null)
                return Result.Failure<GetEmpleadoAsistenciasResponse>(EmpleadoErrors.Obtener);

            var asistencias = await _asistencias.GetByDniYPeriodo(req.Dni, req.Inicio, req.Fin);

            var asistenciasMap = asistencias.Select(MapToEmpleadoAsistencia);

            var response = new GetEmpleadoAsistenciasResponse(empleado.Dni,
                                                              empleado.GetFullName(),
                                                              asistenciasMap);

            return Result.Success(response);
        }

        private GetEmpleadoAsistenciaResponse MapToEmpleadoAsistencia(Asistencia asistencia)
        {
            var ingreso = ConvertirFechasUTC.ToBuenosAiresDateTime(asistencia.Ingreso);
            var egreso = ConvertirFechasUTC.ToBuenosAiresDateTime(asistencia.Egreso);

            return new GetEmpleadoAsistenciaResponse(ingreso, egreso,asistencia.DebeIngresar);
        }
    }
}
