using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.LiquidacionDTO
{
    internal class ItemsDTO
    {
        public List<RemuneracionDTO> Remuneraciones { get; set; } = null!;
        public List<RetencionDTO> Retenciones { get; set; } = null!; 
        public List<DescuentoDTO> Descuentos { get; set; } = null!;
    }
}
