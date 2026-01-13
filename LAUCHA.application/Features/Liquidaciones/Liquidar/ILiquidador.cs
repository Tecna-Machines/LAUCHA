namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public interface ILiquidador
    {
        Task Liquidar(Liquidacion liquidacion, Acuerdo acuerdo);
    }
}
