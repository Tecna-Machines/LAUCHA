using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.ContratoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarContratoTrabajoService
    {
        ContratoDTO ConsultarContrato(string codigoContrato);
        ContratoDTO ObtenerContratoDeEmpleado(string dniEmpleado);
        List<ResumenContratoDTO> ObtenerTodosLosContratosDeEmpleado(string dniEmpleado);
    }
}
