using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.DescuentoDTOs
{
    public class DescuentoComidaDTO
    {
        public int CantidadPedidos { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoDescuento { get; set; }
    }
}
