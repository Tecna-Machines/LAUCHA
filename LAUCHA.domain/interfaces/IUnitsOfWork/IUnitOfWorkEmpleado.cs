using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkEmpleado : IDisposable
    {
        IGenericRepository<Empleado> EmpleadoRepository { get; }
        IGenericRepository<Cuenta> CuentaRepository { get; }
        int Save();
    }
}
