using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class PagoLiquidacion
    {
        public int CodigoPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string CodigoLiquidacion { get; set; } = null!;
        public LiquidacionPersonal Liquidacion { get; set; } = null!;
    }
}
