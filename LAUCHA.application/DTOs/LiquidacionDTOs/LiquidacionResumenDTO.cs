using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.LiquidacionDTOs
{
    public class LiquidacionResumenDTO
    {
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal TotalRemuneraciones { get; set; }
        public decimal TotalRetenciones { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal TotalNoRemunerativo { get; set; }    
        public DateTime Fecha { get; set; }
        public PeriodoDTO Periodo { get; set; } = null!;
    }
}
