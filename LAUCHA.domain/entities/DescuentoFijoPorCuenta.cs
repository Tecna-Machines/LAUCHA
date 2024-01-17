using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class DescuentoFijoPorCuenta
    {
        public string NumeroCuenta { get; set; } = null!;
        public string CodigoDescuento { get; set; } = null!;
    }
}
