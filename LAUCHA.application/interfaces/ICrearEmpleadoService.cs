using LAUCHA.application.DTOs.EmpleadoDTO;

namespace LAUCHA.application.interfaces
{
    public interface ICrearEmpleadoService
    {
        EmpleadoDTO CargarNuevoEmpleado(CrearEmpleadoDTO nuevoEmpleado);
    }
}
