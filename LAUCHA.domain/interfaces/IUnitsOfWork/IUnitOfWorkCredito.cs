using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkCredito
    {
        IGenericRepository<Credito> CreditoRepository { get; }
        IGenericRepository<Cuota> CuotaRepository { get; }
        IGenericRepository<Subcuota> SubCuotaRepository { get; }
        int Save();
    }
}
