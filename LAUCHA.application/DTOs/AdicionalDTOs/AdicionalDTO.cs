using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.AdicionalDTOs
{
    public class AdicionalDTO
    {
        public string Codigo { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public bool EsPorcentual { get; set; }
    }
}
