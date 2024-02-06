using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Descuento
    {
        public string CodigoDescuento { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroConcepto { get; set; }
        public Concepto Concepto { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
        public Cuenta Cuenta { get; set; } = null!;
        public IList<DescuentoPorLiquidacionPersonal> DescuentoPorLiquidacionPersonales { get; set; } = null!;
    }
}
