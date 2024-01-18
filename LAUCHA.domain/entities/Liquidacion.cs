using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Liquidacion
    {
        public string CodigoLiquidacion { get; set; } = null!;
        public decimal IngresoTotal { get; set; }
        public decimal EgresoTotal { get; set; }
        public string Concepto { get; set; } = null!;
        public IList<LiquidacionPorTransaccion> LiquidacionPorTransaccion { get; set; } = null!;
        public PagoLiquidacion PagoLiquidacion { get; set; } = null!;
    }
}
