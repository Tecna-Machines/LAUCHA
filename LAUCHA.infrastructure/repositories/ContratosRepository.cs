using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.repositories
{
    public class ContratosRepository :  IAcuerdoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public ContratosRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public async Task<Acuerdo?> GetActual(string dni)
        {
            return await _context.Acuerdos.OrderByDescending(ac => ac.Fecha)
                                    .Include(ac => ac.Adicionales)
                                    .FirstOrDefaultAsync(ac => ac.DniEmpleado == dni);
        }

        public async Task<ICollection<Acuerdo>> GetHistorial(string dni)
        {
            return await _context.Acuerdos
                                   .Where(ac => ac.DniEmpleado == dni)
                                   .ToListAsync();
        }

        public async Task Insert(Acuerdo acuerdo)
        {
            await _context.Acuerdos.AddAsync(acuerdo);
            await _context.SaveChangesAsync();
        }
    }
}
