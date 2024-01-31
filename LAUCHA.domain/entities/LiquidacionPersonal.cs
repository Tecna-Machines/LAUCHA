using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class LiquidacionPersonal
    {
        public string CodigoLiquidacion { get; set; } = null!;
        public decimal TotalRemuneraciones { get; set; }
        public decimal TotalRetenciones { get; set; }
        public decimal TotalDescuentos { get; set; }
        public string Concepto { get; set; } = null!;
        public PagoLiquidacion PagoLiquidacion { get; set; } = null!;
    }
}
