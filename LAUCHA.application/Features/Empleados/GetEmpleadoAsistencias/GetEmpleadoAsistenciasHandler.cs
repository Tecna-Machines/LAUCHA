using LAUCHA.domain.Entities.Asistencias;
using LAUCHA.domain.Entities.Feriados;

namespace LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias
{
    internal class GetEmpleadoAsistenciasHandler : IGetEmpleadoAsistencias
    {
        private IEmpleadoRepository _empleados;
        private IAsistenciasSource _asistencias;
        private IFeriadoRepository _feriados;

        public GetEmpleadoAsistenciasHandler(IAsistenciasSource asistencias,
                                             IEmpleadoRepository empleados,
                                             IFeriadoRepository feriados)
        {
            _asistencias = asistencias;
            _empleados = empleados;
            _feriados = feriados;
        }

        public async Task<Result<GetEmpleadoAsistenciasResponse>> GetAsistencias(GetEmpleadoAsistenciaRequest req)
        {
            var empleado = await _empleados.GetByDni(req.Dni);

            if (empleado is null)
                return Result.Failure<GetEmpleadoAsistenciasResponse>(EmpleadoErrors.Obtener);

            var asistencias = await _asistencias.GetByDniYPeriodo(req.Dni, req.Inicio, req.Fin);
            var feriados = await _feriados.GetFeriadosDelMes(req.Inicio.Month, req.Inicio.Year);

            var periodo = new PeriodoAsistencias(
                                asistencias.ToList(),
                                feriados.ToList());

            var asistenciasMap = periodo.Asistencias.Select(MapToEmpleadoAsistencia);

            var response = new GetEmpleadoAsistenciasResponse(empleado.Dni,
                                                              empleado.GetFullName(),
                                                              asistenciasMap);

            return Result.Success(response);
        }

        private GetEmpleadoAsistenciaResponse MapToEmpleadoAsistencia(Asistencia asistencia)
        {
            var ingreso = ConvertirFechasUTC.ToBuenosAiresDateTime(asistencia.Ingreso);
            var egreso = ConvertirFechasUTC.ToBuenosAiresDateTime(asistencia.Egreso);

            var hsTrabajadas = asistencia.GetHorasComunes();
            var hsExtras = asistencia.GetHorasExtras();
            var hsTotales = asistencia.GetHorasTotales();
            var hsDoble = asistencia.GetHorasDoble();

            return new GetEmpleadoAsistenciaResponse(ingreso,
                                                     egreso,
                                                     asistencia.DebeIngresar,
                                                     asistencia.EsFeriado() ? "feriado" : "",
                                                     hsExtras,
                                                     hsTrabajadas,
                                                     hsDoble,
                                                     hsTotales);
        }
    }
}
