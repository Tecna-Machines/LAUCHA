using LAUCHA.application.DTOs.ContratoDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarContratoTrabajoService
    {
        ContratoDTO ConsultarContrato(string codigoContrato);
        ContratoDTO ObtenerContratoDeEmpleado(string dniEmpleado);
        List<ResumenContratoDTO> ObtenerTodosLosContratosDeEmpleado(string dniEmpleado);
    }
}
