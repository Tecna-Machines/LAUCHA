using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Remuneracion
    {
        public string CodigoRemuneracion { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool EsBlanco { get; set; }
    }
}
