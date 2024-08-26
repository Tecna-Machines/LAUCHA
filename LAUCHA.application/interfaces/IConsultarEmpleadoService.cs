using LAUCHA.application.DTOs.EmpleadoDTO;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarEmpleadoService
    {
        EmpleadoDTO ConsultarUnEmpleado(string dniEmpleado);
        List<EmpleadoDTO> ConsultarTodosLosEmpleados();
    }
}
