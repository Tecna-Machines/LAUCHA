using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkContrato : IDisposable
    {
        IAcuerdoRepository ContratoRepository { get; }
        IGenericRepository<AcuerdoBlanco> AcuerdoBlancoRepository { get; }
        int Save();
    }
}
