using LAUCHA.application.DTOs.AdicionalDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarAdicionalesService
    {
        AdicionalDTO ObtenerAdicionalPorCodigo(string codigoAdicional);
        List<AdicionalDTO> ObtenerTodosLosAdicionales();
    }
}
