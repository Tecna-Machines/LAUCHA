using LAUCHA.domain.Entities.Liquidacion;

namespace LAUCHA.domain.entities
{
    public class RemuneracionPorLiquidacionPersonal
    {
        public string CodigoRemuneracion { get; set; } = null!;
        public Remuneracion Remuneracion { get; set; } = null!;
        public string CodigoLiquidacionPersonal { get; set; } = null!;
        public Liquidacion LiquidacionPersonal { get; set; } = null!;
    }
}
