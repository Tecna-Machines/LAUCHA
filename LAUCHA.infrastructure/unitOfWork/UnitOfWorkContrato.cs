using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.unitOfWork
{
    public class UnitOfWorkContrato : IUnitOfWorkContrato, IDisposable
    {
        public IGenericRepository<Contrato> ContratoRepository { get; }
        public IGenericRepository<AcuerdoBlanco> AcuerdoBlancoRepository { get; }
        public IGenericRepository<ModalidadPorContrato> ModalidadPorContratoRepository { get; }
        private readonly LiquidacionesDbContext _context;


        public UnitOfWorkContrato(LiquidacionesDbContext context,
                                  IGenericRepository<Contrato> contratoRepository,
                                  IGenericRepository<ModalidadPorContrato> modalidadPorContratoRepository,
                                  IGenericRepository<AcuerdoBlanco> acuerdoBlancoRepository)
        {
            ContratoRepository = contratoRepository;
            ModalidadPorContratoRepository = modalidadPorContratoRepository;
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
