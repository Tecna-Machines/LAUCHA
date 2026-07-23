using LAUCHA.application.Integrations.SysContab;
using LAUCHA.domain.Entities.Pagos;

namespace LAUCHA.application.Features.Liquidaciones.PagarLiquidacion
{
    internal class PagarLiquidacionHandler : IPagarLiquidacion
    {
        private readonly ILiquidacionRepository _liquidaciones;
        private readonly IContabilidadService _sysContabilidad;

        public PagarLiquidacionHandler(ILiquidacionRepository liquidaciones,
                                       IContabilidadService sysContabilidad)
        {
            _liquidaciones = liquidaciones;
            _sysContabilidad = sysContabilidad;
        }

        public async Task<Result<PagoCreadoResponse>> Pagar(CrearPagoRequest req)
        {
            var liquidacion = await _liquidaciones.GetById(req.LiquidacionId);

            if (liquidacion is null)
                return Result.Failure<PagoCreadoResponse>(LiquidacionErrors.NoExistente);

            var pago = new Pago(req.LiquidacionId,
                                req.Descripcion,
                                (Pago.ModoPago)req.Modo,
                                req.Monto);

            if(!req.EsInterno)
            {
                pago.SetPagoComoOficial();
            }

            liquidacion.AgregarPago(pago);


            await _sysContabilidad.RegistrarPagoEnContabilidad(
                  new RegistrarPagoContab(
                        CuentaContableId: req.CuentaContableId,
                        Liquidacion: liquidacion,
                        Pago: pago
                      )
                  );


            await _liquidaciones.Update(liquidacion);

            return Result.Success(
                                 new PagoCreadoResponse(pago.Id,
                                                        pago.Descripcion,
                                                        pago.Monto
                                                       )
                                    );
        }

    }
}
