using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class PagoCreditoDTO
    {
        DateTime FechaPago { get; set; }
        string Descripcion { get; set; } = null!;
        decimal Monto { get; set; }
    }
}
