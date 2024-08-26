using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.unitOfWork
{
    public class UnitOfWorkEmpleado : IUnitOfWorkEmpleado, IDisposable
    {
        public IGenericRepository<Empleado> EmpleadoRepository { get; }
        public IGenericRepository<Cuenta> CuentaRepository { get; }
        private readonly LiquidacionesDbContext _context;

        public UnitOfWorkEmpleado(LiquidacionesDbContext context,
                                IGenericRepository<Cuenta> cuentaRepository,
                                IGenericRepository<Empleado> empleadoRepository)
        {
            _context = context;
            CuentaRepository = cuentaRepository;
            EmpleadoRepository = empleadoRepository;
        }

        public int Save()
        => _context.SaveChanges();


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
