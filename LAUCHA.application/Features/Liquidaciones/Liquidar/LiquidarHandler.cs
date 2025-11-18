using LAUCHA.application.Common.ResultResponse;
using LAUCHA.application.Features.Acuerdos;
using LAUCHA.domain.Entities.Acuerdos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class LiquidarHandler : ILiquidar
    {
        private readonly ILiquidacionDeHaberes _liquidacionDeHaberes;
        private readonly IAcuerdoRepository _acuerdos;
        private readonly ILiquidacionRepository _liquidaciones;

        public LiquidarHandler(ILiquidacionDeHaberes liquidacionDeHaberes,
                               ILiquidacionRepository liquidaciones,
                               IAcuerdoRepository acuerdos)
        {
            _liquidacionDeHaberes = liquidacionDeHaberes;
            _liquidaciones = liquidaciones;
            _acuerdos = acuerdos;
        }

        public async Task<Result<LiquidarResponse>> Liquidar(LiquidarRequest req)
        {
            var liquidacion = await _liquidaciones.GetById(req.Codigo);

            if (liquidacion is null)
                return Result.Failure<LiquidarResponse>(LiquidacionErrors.NoExistente);

            var acuerdo = await _acuerdos.GetById(liquidacion.CodigoAcuerdo);

            if(acuerdo is null)
                return Result.Failure<LiquidarResponse>(AcuerdosErrors.NoEncontrado);

            _liquidacionDeHaberes.Liquidar(liquidacion, acuerdo);

            liquidacion.Sellar();

            await _liquidaciones.Update(liquidacion);

            return Result.Success(new LiquidarResponse(liquidacion.Codigo,liquidacion.Items.Count));
        }
    }
}
