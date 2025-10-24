using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkContrato : IDisposable
    {
        IGenericRepository<Contrato> ContratoRepository { get; }
        IGenericRepository<AcuerdoBlanco> AcuerdoBlancoRepository { get; }
        IGenericRepository<ModalidadPorContrato> ModalidadPorContratoRepository { get; }
        int Save();
    }
}
