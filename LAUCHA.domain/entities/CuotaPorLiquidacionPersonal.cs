using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class CuotaPorLiquidacionPersonal
    {
        public string CodigoCuota { get; set; } = null!;
        public Cuota Cuota { get; set; } = null!;
        public string CodigoLiquidacion { get; set; } = null!;
        public LiquidacionPersonal LiquidacionPersonal { get; set; } = null!;
    }
}
