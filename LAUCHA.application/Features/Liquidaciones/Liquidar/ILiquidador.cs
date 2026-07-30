namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public interface ILiquidador
    {
        Task RecalcularLiquidacion(Liquidacion liquidacion, Acuerdo acuerdo);
    }
}
