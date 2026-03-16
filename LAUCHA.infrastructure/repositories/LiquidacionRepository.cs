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
            return await _db.Liquidaciones
                       .Include(l => l.Items)
                       .Include(l => l.Acuerdo)
                       .Include(l => l.Pagos)
                       .FirstOrDefaultAsync(l => l.Codigo == id);
        }

        public async Task<Liquidacion> Insert(Liquidacion liq)
        {
            await _db.Liquidaciones.AddAsync(liq);
            await _db.SaveChangesAsync();
            return liq;
        }

        public async Task<Liquidacion> Update(Liquidacion liq)
        {
            _db.Liquidaciones.Update(liq);
            await _db.SaveChangesAsync();
            return liq;
        }

        public async Task<IEnumerable<Liquidacion>> GetByQuincena(int quincena, int mes, int anio)
        {
            return await _db.Liquidaciones
                         .Where(l => l.Quincena == quincena && l.Anio == anio && l.Mes == mes)
                         .ToListAsync();
        }
    }
}
