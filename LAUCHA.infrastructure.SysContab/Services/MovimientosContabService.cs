using LAUCHA.infrastructure.SysContab.Models;

namespace LAUCHA.infrastructure.SysContab.Services
{
    internal record CrearMovimientoContab(string CuentaContableId,
                                          string PagoContableId,
                                          string Descripcion,
                                          decimal MontoEnPesos);

    internal class MovimientosContabService
    {
        private readonly TecnaDb3Context _dbTecna;

        public MovimientosContabService(TecnaDb3Context dbTecna)
        {
            _dbTecna = dbTecna;
        }

        public async Task<Movimiento> CrearMovimiento(CrearMovimientoContab crearMov)
        {

            int cuentaContable;
            int pagoId;

            int.TryParse(crearMov.CuentaContableId, out cuentaContable);
            int.TryParse(crearMov.PagoContableId, out pagoId);

            var mov = new Movimiento();
            mov.Id = _dbTecna.Movimientos.Count();
            mov.CuentaId = cuentaContable;
            mov.TipoPago = "pago de sueldo , mediante liquidacion";
            mov.PagoId = pagoId;
            mov.UsuarioId = 997;  // id del sist. de liquidacion
            mov.FechaGeneracion = DateTime.Now;
            mov.MontoDolares = 0;
            mov.MontoEnDolares = false;
            mov.Descripcion = crearMov.Descripcion;
            mov.MontoPesos = (double)crearMov.MontoEnPesos;

            await _dbTecna.Movimientos.AddAsync(mov);
            await _dbTecna.SaveChangesAsync();
            return mov;
        }
    }
}
