using LAUCHA.domain.Entities.RetencionesCatalogo;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.Repositories
{
    internal class CatalogoRetencionesRepository : ICatalogoRetencionRepository
    {
        private readonly LiquidacionesDbContext _db;

        public CatalogoRetencionesRepository(LiquidacionesDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CatalogoRetencion>> GetCatalogo()
        {
            return await _db.CatalogoRetenciones.ToListAsync();
        }

        public async Task<CatalogoRetencion?> GetRetencion(string codigo)
        {
            return await _db.CatalogoRetenciones.FindAsync(codigo);
        }

        public async Task<CatalogoRetencion> Insert(CatalogoRetencion retencionCatalogo)
        {
            await _db.CatalogoRetenciones.AddAsync(retencionCatalogo);
            await _db.SaveChangesAsync();
            return retencionCatalogo;
        }
    }
}
