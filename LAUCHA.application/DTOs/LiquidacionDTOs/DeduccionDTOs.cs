using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.SueldosDTOs;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.LiquidacionDTOs
{
    public class DeduccionDTOs
    {
        public string Empleado { get; set; } = null!;
        public DateTime FinPeriodo { get; set; }
        public DateTime InicioPeriodo { get; set; }
        public List<RetencionDTO> Retenciones { get; set; } = null!;
        public List<RemuneracionDTO> Remuneraciones { get; set; } = null!;
    }
}
