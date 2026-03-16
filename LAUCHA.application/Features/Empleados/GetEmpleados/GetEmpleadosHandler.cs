namespace LAUCHA.application.Features.Empleados.GetEmpleados
{
    internal class GetEmpleadosHandler : IGetEmpleados
    {
        private readonly IEmpleadoRepository _empleados;
        private readonly IAcuerdoRepository _acuerdos;

        public GetEmpleadosHandler(IEmpleadoRepository repository,
                                   IAcuerdoRepository acuerdos)
        {
            _empleados = repository;
            _acuerdos = acuerdos;
        }

        public async Task<Result<GetEmpleadosResponse>> GetEmpleados()
        {
            IEnumerable<Empleado> empleados;

            try
            {
                empleados = await _empleados.GetAll();

            }
            catch (Exception)
            {
                return Result.Failure<GetEmpleadosResponse>(EmpleadoErrors.Obtener);
            }

            return Result.Success(await MapToResponse(empleados));
        }

        private async Task<GetEmpleadosResponse> MapToResponse(IEnumerable<Empleado> empleados)
        {
            List<GetEmpleadoResponse> responses = new();

            foreach (var emp in empleados)
            {
                responses.Add(await MapEmpleado(emp));
            }

            return new GetEmpleadosResponse(responses.Count, responses);
        }

        private async Task<GetEmpleadoResponse> MapEmpleado(Empleado emp)
        {
            var acuerdo = await _acuerdos.GetActual(emp.Dni);

            string codigoAcuerdo = acuerdo is null ? string.Empty : acuerdo.Codigo;
            int tipoSueldo = acuerdo is null ? -1 : (int)acuerdo.TipoSueldo;

            return new GetEmpleadoResponse(emp.Dni,
                                           emp.Nombre,
                                           emp.Apellido,
                                           "emp.Cuenta.NumeroCuenta",
                                           codigoAcuerdo,
                                           tipoSueldo);
        }
    }
}
