using LAUCHA.domain.Entities.Liquidaciones;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.Repositories
{
    internal class LiquidacionRepository : ILiquidacionRepository
    {
        private readonly LiquidacionesDbContext _db;

        public LiquidacionRepository(LiquidacionesDbContext db)
        {
            _db = db;
        }

        public async Task<Liquidacion?> GetById(string id)
        {
            return await _db.LiquidacionesPersonales
                       .Include(l => l.Items)
                       .Include(l => l.Acuerdo)
                       .FirstOrDefaultAsync(l => l.Codigo == id);
        }

        public async Task<Liquidacion> Insert(Liquidacion liq)
        {
            await _db.LiquidacionesPersonales.AddAsync(liq);
            await _db.SaveChangesAsync();
            return liq;
        }

        public async Task<Liquidacion> Update(Liquidacion liq)
        {
            _db.LiquidacionesPersonales.Update(liq);
            await _db.SaveChangesAsync();
            return liq;
        }

        public async Task<IEnumerable<Liquidacion>> GetByQuincena(int quincena, int mes, int anio)
        {
            return await _db.LiquidacionesPersonales
                         .Where(l => l.Quincena == quincena && l.Anio == anio && l.Mes == mes)
                         .ToListAsync();
        }
    }
}
