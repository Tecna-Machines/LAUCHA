using LAUCHA.application.Integrations.SysContab;

namespace LAUCHA.infrastructure.SysContab.Services
{
    internal class ContabilidadService : IContabilidadService
    {
        private readonly PagosContabService _pagosContab;
        private readonly MovimientosContabService _movimientosContab;

        public ContabilidadService(PagosContabService pagosContab,
                                   MovimientosContabService movimientosContab)
        {
            _pagosContab = pagosContab;
            _movimientosContab = movimientosContab;
        }

        public async Task RegistrarPagoEnContabilidad(RegistrarPagoContab req)
        {
            var liquidacion = req.Liquidacion;

            if (liquidacion.TieneImpactoContable())
            {
                string referenciaContable = liquidacion.ObtenerReferenciaContable()!;

                await AgregarMovimientoAPagoExistente(req, referenciaContable);
            }
            else
            {
                await CargarPagoPrimeraVez(req);
            }
        }

        private async Task CargarPagoPrimeraVez(RegistrarPagoContab req)
        {
            var pagoContab = await _pagosContab.CrearPago(req.Liquidacion.Concepto);
            string referenciaContable = pagoContab.Id.ToString();

            var crearMov = new CrearMovimientoContab(
                                                     CuentaContableId: req.CuentaContableId,
                                                     PagoContableId: referenciaContable,
                                                     Descripcion: req.Liquidacion.Concepto,
                                                     MontoEnPesos: req.Pago.Monto);

            var movContab = await _movimientosContab.CrearMovimiento(crearMov);
            req.Pago.MarcarComoEnviado(referenciaContable);
        }

        private async Task AgregarMovimientoAPagoExistente(RegistrarPagoContab req,
                                                          string referenciaContable)
        {
            var crearMov = new CrearMovimientoContab(
                                         CuentaContableId: req.CuentaContableId,
                                         PagoContableId: referenciaContable,
                                         Descripcion: req.Liquidacion.Concepto,
                                         MontoEnPesos: req.Pago.Monto);

            var movContab = await _movimientosContab.CrearMovimiento(crearMov);
            req.Pago.MarcarComoEnviado(referenciaContable);
        }


    }
}
