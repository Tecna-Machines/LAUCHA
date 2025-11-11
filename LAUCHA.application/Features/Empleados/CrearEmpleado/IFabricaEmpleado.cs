using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    public interface IFabricaEmpleado
    {
        Empleado Crear(CrearEmpleadoRequest req);
    }
}
