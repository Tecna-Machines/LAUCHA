using LAUCHA.domain.Entities.Liquidacion;

namespace LAUCHA.domain.entities
{
    public class NoRemuneracionPorLiquidacionPersonal
    {
        public string CodigoNoRemuneracion { get; set; } = null!;
        public NoRemuneracion NoRemuneracion { get; set; } = null!;
        public string CodigoLiquidacionPersonal { get; set; } = null!;
        public Liquidacion LiquidacionPersonal { get; set; } = null!;
    }
}
