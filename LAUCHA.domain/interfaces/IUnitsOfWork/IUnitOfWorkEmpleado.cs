using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkEmpleado : IDisposable
    {
        IGenericRepository<Empleado> EmpleadoRepository { get; }
        IGenericRepository<Cuenta> CuentaRepository { get; }
        int Save();
    }
}
