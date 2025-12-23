using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public EmpleadoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }
        public async Task Insert(Empleado emp)
        {
            await _context.AddAsync(emp);
            await _context.SaveChangesAsync();
        }

        public Task<Empleado> Update(Empleado emp)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Empleado>> FindByNameOrSurname(string name)
        {
            return await _context.Empleados
                        .AsNoTracking()
                        .Where(emp =>
                                EF.Functions.Like(emp.Nombre.ToLower(), $"%{name.ToLower()}%") ||
                                EF.Functions.Like(emp.Apellido.ToLower(), $"%{name.ToLower()}%"))
                        .ToListAsync();
        }

        public async Task<IEnumerable<Empleado>> GetAll()
        {
            return await _context.Empleados.Include(e => e.Cuenta).ToListAsync();
        }

        public async Task<Empleado?> GetByDni(string dni)
        {
            return await _context.Empleados.FindAsync(dni);
        }

    }

    public class Borrame : IGenericRepository<Empleado>
    {
        public Empleado Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Empleado> GetAll()
        {
            throw new NotImplementedException();
        }

        public Empleado GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Empleado Insert(Empleado entity)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Empleado Update(Empleado entity)
        {
            throw new NotImplementedException();
        }
    }
}
