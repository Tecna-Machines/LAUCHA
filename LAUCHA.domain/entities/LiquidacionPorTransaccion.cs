using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class LiquidacionPorTransaccion
    {
        public string NumeroTransacccion { get; set; } = null!;
        public Transaccion Transaccion { get; set; } = null!;
        public string CodigoLiquidacion { get; set; } = null!;
        public Liquidacion Liquidacion { get; set; } = null!;
    }
}
