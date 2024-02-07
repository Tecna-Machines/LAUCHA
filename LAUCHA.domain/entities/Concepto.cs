using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Concepto
    {
        public int NumeroConcepto { get; set; }
        public string NombreConcepto { get; set; } = null!;
        public ICollection<Descuento> Descuentos { get; set; } = null!;
        public ICollection<Credito> Creditos { get; set; } = null!;
    }
}
