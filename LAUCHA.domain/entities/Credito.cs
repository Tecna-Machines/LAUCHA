using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Credito
    {
        public string CodigoCredito { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Descripcion { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
        public Cuenta Cuenta { get; set; } = null!;
        public ICollection<Cuota> Cuotas { get; set; } = null!;
        public int NumeroConcepto { get; set; }
        public Concepto Concepto { get; set; } = null!;
    }
}
