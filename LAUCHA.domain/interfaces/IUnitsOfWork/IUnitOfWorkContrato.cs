using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkContrato : IDisposable
    {
        IGenericRepository<Acuerdo> ContratoRepository { get; }
        IGenericRepository<AcuerdoBlanco> AcuerdoBlancoRepository { get; }
        int Save();
    }
}
