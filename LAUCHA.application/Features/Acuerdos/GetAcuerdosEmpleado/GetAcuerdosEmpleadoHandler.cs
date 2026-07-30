using LAUCHA.application.Mappers;

namespace LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado
{
    internal class GetAcuerdosEmpleadoHandler : IGetAcuerdosEmpleado
    {
        private readonly IAcuerdoRepository _acuerdos;
        private readonly IEmpleadoRepository _empleados;

        public GetAcuerdosEmpleadoHandler(IAcuerdoRepository acuerdos,
                                          IEmpleadoRepository empleados)
        {
            _acuerdos = acuerdos;
            _empleados = empleados;
        }

        public async Task<Result<GetAcuerdosEmpleadosResponse>> GetAcuerdosEmpleado(GetAcuerdosEmpleadoRequest req)
        {
            Empleado? empleado = await _empleados.GetByDni(req.Dni);

            if (empleado is null)
                return Result.Failure<GetAcuerdosEmpleadosResponse>(AcuerdosErrors.NoEncontrado);

            var acuerdos = await GetHistorialAcuerdos(empleado.Dni);

            GetAcuerdosEmpleadosResponse result = new(empleado.Dni, empleado.Nombre, empleado.Apellido, acuerdos);

            return Result.Success(result);
        }

        private async Task<IEnumerable<GetAcuerdoEmpleado>> GetHistorialAcuerdos(string dni)
        {
            var acuerdos = await _acuerdos.GetHistorial(dni);

            var historial = acuerdos
                            .OrderByDescending(a => a.Fecha)
                            .Select(MapAcuerdo)
                            .ToList();

            return historial;
        }

        private GetAcuerdoEmpleado MapAcuerdo(Acuerdo acu)
        {
            return new GetAcuerdoEmpleado(acu.Codigo,
                                          acu.Fecha,
                                          acu.ValorHora,
                                          acu.ValorSueldoOJornal,
                                          acu.Sueldo,
                                          TipoSueldoMapper.ToInt(acu.TipoSueldo),
                                          JornadaMapper.ToJornadaLabolal(acu.Jornada),
                                          acu.Notas ?? "");
        }

    }
}
