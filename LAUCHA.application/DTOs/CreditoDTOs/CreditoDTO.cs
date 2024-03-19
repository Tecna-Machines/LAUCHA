using LAUCHA.application.DTOs.ConceptoDTOs;

namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class CreditoDTO
    {
        public string Codigo { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public ConceptoDTO Concepto { get; set; } = null!;
        public int CantidadCuotasFaltantes { get; set; } = -1;
        public decimal MontoCuota { get; set; } = -1;
        public decimal MontoFaltante { get; set; } = -1;
    }
}
