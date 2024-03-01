using LAUCHA.application.DTOs.ConceptoDTOs;

namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class CreditoDTO
    {
        public string Codigo { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public ConceptoDTO Concepto { get; set; } = null!;
        public List<CuotaDTO> Cuotas { get; set; } = null!;
        public List<SubCuotaDTO> SubCuotas { get; set; } = null!;
    }
}
