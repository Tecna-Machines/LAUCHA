using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.unitOfWork
{
    public class UnitOfWorkCredito : IUnitOfWorkCredito, IDisposable
    {
        public IGenericRepository<Credito> CreditoRepository { get; }
        public IGenericRepository<Cuota> CuotaRepository { get; }
        public IGenericRepository<Subcuota> SubCuotaRepository { get; }
        private readonly LiquidacionesDbContext _context;

        public UnitOfWorkCredito(IGenericRepository<Credito> creditoRepository,
                                 IGenericRepository<Cuota> cuotaRepository,
                                 IGenericRepository<Subcuota> subCuotaRepository,
                                 LiquidacionesDbContext context)
        {
            CreditoRepository = creditoRepository;
            CuotaRepository = cuotaRepository;
            SubCuotaRepository = subCuotaRepository;
            _context = context;
        }


        public int Save()
        => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
