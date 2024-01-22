using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class LiquidacionPorTransaccion
    {
        public long NumeroTransaccion { get; set; }
        public Transaccion Transaccion { get; set; } = null!;
        public string CodigoLiquidacion { get; set; } = null!;
        public Liquidacion Liquidacion { get; set; } = null!;
    }
}
