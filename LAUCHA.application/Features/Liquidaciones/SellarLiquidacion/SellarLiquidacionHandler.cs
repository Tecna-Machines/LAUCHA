namespace LAUCHA.application.Features.Liquidaciones.SellarLiquidacion
{
    internal class SellarLiquidacionHandler : ISellarLiquidacion
    {
        private readonly ILiquidacionRepository _liquidaciones;

        public SellarLiquidacionHandler(ILiquidacionRepository liquidaciones)
        {
            _liquidaciones = liquidaciones;
        }

        public async Task<Result<SellarLiquidacionResponse>> Sellar(string codigo)
        {
            var liq = await _liquidaciones.GetById(codigo);

            if (liq is null)
                return Result.Failure<SellarLiquidacionResponse>(LiquidacionErrors.NoExistente);

            liq.Sellar();

            await _liquidaciones.Update(liq);

            return Result.Success(new SellarLiquidacionResponse(liq.Codigo, liq.FechaSello));
        }
    }
}
