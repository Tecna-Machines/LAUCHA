using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    public interface ICrearEmpleado
    {
        Task<Result<CrearEmpleadoResponse>> Crear(CrearEmpleadoRequest req);
    }
}
