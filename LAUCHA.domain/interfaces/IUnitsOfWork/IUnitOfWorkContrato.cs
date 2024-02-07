using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkContrato : IDisposable
    {
        IGenericRepository<Contrato> ContratoRepository { get; }
        IGenericRepository<AcuerdoBlanco> AcuerdoBlancoRepository { get; }
        IGenericRepository<ModalidadPorContrato> ModalidadPorContratoRepository { get; }
        IGenericRepository<AdicionalPorContrato> AdicionalPorContratoRepositoy { get; }
        int Save();
    }
}
