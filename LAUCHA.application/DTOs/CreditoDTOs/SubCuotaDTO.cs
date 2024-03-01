using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class SubCuotaDTO
    {
        public string Codigo { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime FechaPagar { get; set; }
        public string Cuota { get; set; } = null!;
    }
}
