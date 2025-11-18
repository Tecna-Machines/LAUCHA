using LAUCHA.domain.entities;
using LAUCHA.domain.Entities.Liquidaciones;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.unitOfWork
{
    public class UnitOfWorkLiquidacion : IUnitOfWorkLiquidacion, IDisposable
    {
        public IGenericRepository<RetencionOLD> RetencionRepository { get; }
        public IGenericRepository<NoRemuneracion> NORemuneracionRepository { get; }
        public IGenericRepository<Remuneracion> RemuneracionRepository { get; }
        public IGenericRepository<Descuento> DescuentoRepository { get; }
        public IGenericRepository<Liquidacion> LiquidacionRepository { get; }
        public IGenericRepository<RemuneracionPorLiquidacionPersonal> RemuneracionLiquidacion { get; }
        public IGenericRepository<RetencionPorLiquidacionPersonal> RetencionLiquidacion { get; }
        public IGenericRepository<DescuentoPorLiquidacionPersonal> DescuentoLiquidacion { get; }
        public IGenericRepository<NoRemuneracionPorLiquidacionPersonal> NoRemuneracionLiquidacion { get; }

        private readonly LiquidacionesDbContext _context;


        public UnitOfWorkLiquidacion(IGenericRepository<Remuneracion> remuneracionRepository,
                                     LiquidacionesDbContext context,
                                     IGenericRepository<RetencionOLD> retencionRepository,
                                     IGenericRepository<RemuneracionPorLiquidacionPersonal> remuneracionLiquidacion,
                                     IGenericRepository<RetencionPorLiquidacionPersonal> retencionLiquidacion,
                                     IGenericRepository<DescuentoPorLiquidacionPersonal> descuentoLiquidacion,
                                     IGenericRepository<Liquidacion> liquidacionRepository,
                                     IGenericRepository<NoRemuneracionPorLiquidacionPersonal> noRemuneracionLiquidacion,
                                     IGenericRepository<NoRemuneracion> nORemuneracionRepository,
                                     IGenericRepository<Descuento> descuentoRepository)
        {
            _context = context;
            RemuneracionRepository = remuneracionRepository;
            RetencionRepository = retencionRepository;
            RemuneracionLiquidacion = remuneracionLiquidacion;
            RetencionLiquidacion = retencionLiquidacion;
            DescuentoLiquidacion = descuentoLiquidacion;
            LiquidacionRepository = liquidacionRepository;
            NoRemuneracionLiquidacion = noRemuneracionLiquidacion;
            NORemuneracionRepository = nORemuneracionRepository;
            DescuentoRepository = descuentoRepository;
        }


        public int Save()
        => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
