using LAUCHA.application.Features.Acuerdos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class LiquidarHandler : ILiquidar
    {
        private readonly ILiquidador _liquidador;
        private readonly IAcuerdoRepository _acuerdos;
        private readonly ILiquidacionRepository _liquidaciones;

        public LiquidarHandler(ILiquidador liquidacionDeHaberes,
                               ILiquidacionRepository liquidaciones,
                               IAcuerdoRepository acuerdos)
        {
            _liquidador = liquidacionDeHaberes;
            _liquidaciones = liquidaciones;
            _acuerdos = acuerdos;
        }

        public async Task<Result<LiquidarResponse>> Liquidar(LiquidarRequest req)
        {
            var liquidacion = await _liquidaciones.GetById(req.Codigo);

            if (liquidacion is null)
                return Result.Failure<LiquidarResponse>(LiquidacionErrors.NoExistente);

            if (liquidacion.EstaSellada())
                return Result.Failure<LiquidarResponse>(LiquidacionErrors.Sellada);

            var acuerdo = await _acuerdos.GetById(liquidacion.CodigoAcuerdo);

            if (acuerdo is null)
                return Result.Failure<LiquidarResponse>(AcuerdosErrors.NoEncontrado);

            await _liquidador.Liquidar(liquidacion, acuerdo);

            //liquidacion.Sellar();

            await _liquidaciones.Update(liquidacion);

            return Result.Success(new LiquidarResponse(liquidacion.Codigo, liquidacion.Items.Count));
        }
    }
}
