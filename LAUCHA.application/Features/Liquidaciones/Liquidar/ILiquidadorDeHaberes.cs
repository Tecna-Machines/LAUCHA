namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public interface ILiquidadorDeHaberes
    {
        void Liquidar(Liquidacion liquidacion, Acuerdo acuerdo);
    }
}
