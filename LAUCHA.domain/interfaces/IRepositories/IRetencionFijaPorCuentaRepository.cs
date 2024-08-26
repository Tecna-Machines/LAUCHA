using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IRetencionFijaPorCuentaRepository
    {
        List<RetencionFijaPorCuenta> ObtenerRetencionesFijasDeUnaCuenta(string NumeroCuenta);
    }
}
