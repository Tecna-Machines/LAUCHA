namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public interface ILiquidar
    {
        public Task<Result<LiquidarResponse>> Liquidar(LiquidarRequest req);
    }
}
