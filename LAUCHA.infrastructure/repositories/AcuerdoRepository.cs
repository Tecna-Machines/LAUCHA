using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    internal class AcuerdoRepository : IAcuerdoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public AcuerdoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public async Task<Acuerdo?> GetActual(string dni)
        {
            return await _context.Acuerdos.OrderByDescending(ac => ac.Fecha)
                                    .Include(ac => ac.Adicionales)
                                    .Include(ac => ac.Retenciones)
                                    .FirstOrDefaultAsync(ac => ac.DniEmpleado == dni);
        }

        public async Task<ICollection<Acuerdo>> GetHistorial(string dni)
        {
            return await _context.Acuerdos
                                   .Where(ac => ac.DniEmpleado == dni)
                                   .OrderByDescending(ac => ac.Fecha)
                                   .ToListAsync();
        }

        public async Task Insert(Acuerdo acuerdo)
        {
            await _context.Acuerdos.AddAsync(acuerdo);
            await _context.SaveChangesAsync();
        }

        public async Task<Acuerdo?> GetById(string id)
        {
            return await _context.Acuerdos
                         .Include(ac => ac.Empleado)
                         .Include(ac => ac.Adicionales)
                         .Include(ac => ac.Retenciones)
                         .FirstOrDefaultAsync(ac => ac.Codigo == id);
        }
    }
}
