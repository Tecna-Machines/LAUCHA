using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class PagoCreditoDTO
    {
        public DateTime FechaPago { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
    }
}
