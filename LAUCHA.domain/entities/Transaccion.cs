using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Transaccion
    {
        public long NumeroTransaccion {  get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; } = null!;
        public bool Tipo {  get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroCuenta { get; set; } = null!;
    }
}
