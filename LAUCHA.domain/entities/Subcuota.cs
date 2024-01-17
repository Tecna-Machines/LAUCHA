using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Subcuota
    {
        public string CodigoSubcuota { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime FechaDebePagar { get; set; }
        public string CodigoCuota { get; set; } = null!;
    }
}
