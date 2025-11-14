using LAUCHA.domain.Entities.Liquidacion;

namespace LAUCHA.domain.entities
{
    public class LiquidacionGeneral
    {
        public string CodigoLiquidacionGeneral { get; set; } = null!;
        public decimal TotalRemuneracion { get; set; }
        public decimal TotalRetencion { get; set; }
        public decimal TotalDescuentos { get; set; }
        public DateTime InicioPeriodo { get; set; }
        public DateTime FinPeriodo { get; set; }
        public ICollection<Liquidacion> LiquidacionesPersonales { get; set; } = null!;
    }
}
