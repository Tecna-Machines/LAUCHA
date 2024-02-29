using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class NoRemuneracionPorLiquidacionPersonal
    {
        public string CodigoNoRemuneracion { get; set; } = null!;
        public NoRemuneracion NoRemuneracion { get; set; } = null!;
        public string CodigoLiquidacionPersonal { get; set; } = null!;
        public LiquidacionPersonal LiquidacionPersonal { get; set; } = null!;
    }
}
