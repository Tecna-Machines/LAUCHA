using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkLiquidacion : IDisposable
    {
        IGenericRepository<Remuneracion> RemuneracionRepository { get; }
        IGenericRepository<NoRemuneracion> NORemuneracionRepository { get; }
        IGenericRepository<Descuento> DescuentoRepository { get; }
        IGenericRepository<Retencion> RetencionRepository { get; }

        IGenericRepository<RemuneracionPorLiquidacionPersonal> RemuneracionLiquidacion { get; }
        IGenericRepository<RetencionPorLiquidacionPersonal> RetencionLiquidacion { get; }
        IGenericRepository<DescuentoPorLiquidacionPersonal> DescuentoLiquidacion { get; }
        IGenericRepository<NoRemuneracionPorLiquidacionPersonal> NoRemuneracionLiquidacion { get; }

        IGenericRepository<LiquidacionPersonal> LiquidacionRepository { get; }
        int Save();
    }
}
