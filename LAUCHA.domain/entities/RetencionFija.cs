using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class RetencionFija
    {
        public string CodigoRetencionFija { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; } 
        public bool EsPorcentual { get; set; }
        public ICollection<HistorialRetencionFija> HistorialRetencionesFijas { get; set; } = null!;
        public IList<RetencionFijaPorCuenta> RetencionesFijasPorCuenta { get; set; } = null!;

    }
}
