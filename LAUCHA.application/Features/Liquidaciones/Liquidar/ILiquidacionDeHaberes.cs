using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public interface ILiquidacionDeHaberes
    {
        void Liquidar(Liquidacion liquidacion, Acuerdo acuerdo);
    }
}
