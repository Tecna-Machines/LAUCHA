using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.LiquidacionDTO
{
    internal class PagoDTO
    {
        public int codigo { get; set; }
        public string Fecha { get; set; } = null!;
        public decimal Monto { get; set; }
    }
}
