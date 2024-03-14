using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;

namespace LAUCHA.application.DTOs.LiquidacionDTOs
{
    public class ItemsDTO
    {
        public List<RemuneracionDTO> Remuneraciones { get; set; } = null!;
        public List<RetencionDTO> Retenciones { get; set; } = null!;
        public List<DescuentoDTO> Descuentos { get; set; } = null!;
        public List<NoRemuneracionDTO> NoRemuneraciones { get; set; } = null!;
    }
}
