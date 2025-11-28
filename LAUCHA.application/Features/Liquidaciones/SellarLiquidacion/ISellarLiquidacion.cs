namespace LAUCHA.application.Features.Liquidaciones.SellarLiquidacion
{
    public interface ISellarLiquidacion
    {
        Task<Result<SellarLiquidacionResponse>> Sellar(string codigo);
    }
}
