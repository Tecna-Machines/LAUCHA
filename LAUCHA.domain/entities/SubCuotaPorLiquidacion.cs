using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class SubCuotaPorLiquidacion
    {
        public string CodigoSubcuota { get; set; } = null!;
        public Subcuota Subcuota { get; set; } = null!;
        public string CodigoLiquidacion { get; set; } = null!;
        public LiquidacionPersonal LiquidacionPersonal { get; set; } = null!;
    }
}
