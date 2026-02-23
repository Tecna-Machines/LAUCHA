using LAUCHA.domain.Entities.Asistencias;

namespace LAUCHA.application.Features.Empleados.CrearEmpleadoAsistencias
{
    internal class CrearEmpleadoAsistenciaHandler : ICrearAsistencia
    {
        private readonly IAsistenciasSource _asistencias;

        public CrearEmpleadoAsistenciaHandler(IAsistenciasSource asistencias)
        {
            _asistencias = asistencias;
        }

        public async Task<Result<CrearEmpleadoAsistenciaResponse>> Crear(CrearEmpleadoAsistenciaRequest req)
        {
            var asistencia = Asistencia.Crear(req.Dni, req.Entrada, req.Salida, null);

            await _asistencias.Insert(asistencia);

            return Result.Success(new CrearEmpleadoAsistenciaResponse(asistencia.DniEmpleado,
                                                                      asistencia.Ingreso.Value.DateTime,
                                                                      asistencia.Egreso.Value.DateTime));
        }

    }
}
