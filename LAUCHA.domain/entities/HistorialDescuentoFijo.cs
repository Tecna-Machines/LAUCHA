using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class HistorialDescuentoFijo
    {
        public string CodigoDescuento { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public string Tipo { get; set; } = null!;
        public DateTime FechaFinVigencia { get; set; }
        public DescuentoFijo DescuentoFijo { get; set; } = null!;  
    }
}
