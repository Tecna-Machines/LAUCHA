using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Cuota
    {
        public string CodigoCuota { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime FechaDebePagar { get; set; }
        public string CodigoCredito { get; set; } = null!;
    }
}
