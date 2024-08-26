using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkRetencionFijaCuenta : IDisposable
    {
        IGenericRepository<RetencionFijaPorCuenta> RetencionFijaRepository { get; }
        int Save();
    }
}
