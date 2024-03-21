using LAUCHA.application.DTOs.ConceptoDTOs;

namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class CreditoDTO
    {
        public string Codigo { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public ConceptoDTO Concepto { get; set; } = null!;
        public int CantidadCuotasFaltantes { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal MontoFaltante { get; set; }
        public List<PagoCreditoDTO> Pagos { get; set; } = null!;
    }
}
