using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.CuentaDTOs
{
    public class CuentaDTO
    {
        public string NumeroCuenta { get; set; } = null!;
        public string Empleado { get; set; } = null!;
        public List<RetencionFijaDTO> Retenciones { get; set; } = null!; 
    }
}
