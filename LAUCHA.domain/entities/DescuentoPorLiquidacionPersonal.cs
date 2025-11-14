using LAUCHA.domain.Entities.Liquidacion;

namespace LAUCHA.domain.entities
{
    public class DescuentoPorLiquidacionPersonal
    {
        public string CodigoDescuento { get; set; } = null!;
        public Descuento Descuento { get; set; } = null!;
        public string CodigoLiquidacionPersonal { get; set; } = null!;
        public Liquidacion LiquidacionPersonal { get; set; } = null!;
    }
}
