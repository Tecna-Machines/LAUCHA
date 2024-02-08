using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkRetencionFijaCuenta : IDisposable
    {
        IGenericRepository<RetencionFijaPorCuenta> RetencionFijaRepository { get; }
        int Save();
    }
}
