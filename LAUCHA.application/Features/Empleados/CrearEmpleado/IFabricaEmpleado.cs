using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    public interface IFabricaEmpleado
    {
        Task<Empleado> Crear(CrearEmpleadoRequest req);
    }
}
