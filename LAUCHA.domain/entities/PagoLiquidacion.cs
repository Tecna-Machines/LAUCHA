using LAUCHA.domain.Entities.Liquidacion;

namespace LAUCHA.domain.entities
{
    public class PagoLiquidacion
    {
        public int CodigoPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string CodigoLiquidacion { get; set; } = null!;
        public Liquidacion Liquidacion { get; set; } = null!;
    }
}
