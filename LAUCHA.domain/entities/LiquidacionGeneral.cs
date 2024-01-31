using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class LiquidacionGeneral
    {
        public string CodigoLiquidacionGeneral { get; set; } = null!;
        public decimal TotalRemuneracion { get; set; }
        public decimal TotalRetencion { get; set; }
        public decimal TotalDescuentos { get; set; }
    }
}
