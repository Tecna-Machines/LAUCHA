namespace LAUCHA.application.Features.Liquidaciones.PagarLiquidacion
{
    internal class PagarLiquidacionHandler : IPagarLiquidacion
    {
        private readonly ILiquidacionRepository _liquidaciones;

        public PagarLiquidacionHandler(ILiquidacionRepository liquidaciones)
        {
            _liquidaciones = liquidaciones;
        }

        public async Task<Result<PagoCreadoResponse>> Pagar(CrearPagoRequest req)
        {
            var liquidacion = await _liquidaciones.GetById(req.LiquidacionId);

            if (liquidacion is null)
                return Result.Failure<PagoCreadoResponse>(LiquidacionErrors.NoExistente);

            var pago = new Pago(req.LiquidacionId, req.Descripcion);

            if (req.Modo == (int)Pago.ModoPago.EFECTIVO)
            {
                pago.AbonarEnEfectivo(req.Monto);
            }
            else
            {
                pago.AbonarEnTransferencia(req.Monto);
            }

            liquidacion.AgregarPago(pago);

            await _liquidaciones.Update(liquidacion);


            return Result.Success(new PagoCreadoResponse(pago.Id, pago.Descripcion, pago.Monto));

        }
    }
}
