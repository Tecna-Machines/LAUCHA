using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface ICuentaRepository
    {
        Cuenta ObtenerCuentaDelEmpleado(string dniEmpleado);
    }
}
