using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.unitOfWork
{
    public class UnitOfWorkContrato : IUnitOfWorkContrato, IDisposable
    {
        public IAcuerdoRepository ContratoRepository { get; }
        public IGenericRepository<AcuerdoBlanco> AcuerdoBlancoRepository { get; }
        private readonly LiquidacionesDbContext _context;


        public UnitOfWorkContrato(LiquidacionesDbContext context,
                                  IAcuerdoRepository contratoRepository,
                                  IGenericRepository<AcuerdoBlanco> acuerdoBlancoRepository)
        {
            ContratoRepository = contratoRepository;
            _context = context;
            AcuerdoBlancoRepository = acuerdoBlancoRepository;
        }

        public int Save()
        => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
