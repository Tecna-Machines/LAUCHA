using LAUCHA.application.DTOs.ConceptoDTOs;

namespace LAUCHA.application.DTOs.DescuentoDTOs
{
    public class DescuentoDTO
    {
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public ConceptoDTO Concepto { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
    }
}
