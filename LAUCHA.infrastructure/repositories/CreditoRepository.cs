using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.Repositories
{
    internal class CreditoRepository : ICreditoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public CreditoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Credito>> GetAll()
        {
            return await _context.Creditos.ToListAsync();
        }

        public async Task<IEnumerable<Credito>> GetByEmpleado(string dni)
        {
            return await _context.Creditos.Where(c => c.DniEmpleado == dni).ToListAsync();
        }

        public async Task<Credito?> GetById(string id)
        {
            return await _context.Creditos.Include(c => c.Cuotas)
                                          .FirstOrDefaultAsync(c => c.Codigo == id);
        }

        public async Task<Credito> Insert(Credito credito)
        {
            await _context.Creditos.AddAsync(credito);
            await _context.SaveChangesAsync();

            return credito;
        }

        public async Task<Credito> Update(Credito credito)
        {
            _context.Creditos.Update(credito);
            await _context.SaveChangesAsync();

            return credito;
        }
    }
}
