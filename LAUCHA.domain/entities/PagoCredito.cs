using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class PagoCredito
    {
        public string CodigoDescuento { get; set; } = null!;
        public string CodigoCredito { get; set; } = null!;
        public DateTime FechaPago {  get; set; }
        public decimal Monto { get; set; }

    }
}
