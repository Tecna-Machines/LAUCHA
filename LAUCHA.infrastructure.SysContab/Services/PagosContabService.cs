using LAUCHA.infrastructure.SysContab.Models;

namespace LAUCHA.infrastructure.SysContab.Services
{
    internal class PagosContabService
    {
        private readonly TecnaDb3Context _dbTecna;

        public PagosContabService(TecnaDb3Context dbTecna)
        {
            _dbTecna = dbTecna;
        }

        public async Task<Pago> CrearPago(string descripcion)
        {
            var pagoContab = new Pago();

            pagoContab.Id = _dbTecna.Pagos.Count();
            pagoContab.FechaPago = DateTime.Now;
            pagoContab.Descripcion = descripcion;
            pagoContab.UsuarioId = 997;

            await _dbTecna.Pagos.AddAsync(pagoContab);
            await _dbTecna.SaveChangesAsync();

            return pagoContab;
        }
    }
}
