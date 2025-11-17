using LAUCHA.domain.Entities.Liquidaciones;

namespace LAUCHA.domain.entities
{
    public class RetencionPorLiquidacionPersonal
    {
        public string CodigoRetencion { get; set; } = null!;
        public Retencion Retencion { get; set; } = null!;
        public string CodigoLiquidacionPersonal { get; set; } = null!;
        public Liquidacion LiquidacionPersonal { get; set; } = null!;
    }
}
