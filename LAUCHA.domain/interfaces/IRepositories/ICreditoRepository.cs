using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface ICreditoRepository
    {
        List<Credito> ObtenerCreditosSinPagarDeCuenta(string NumeroCuenta);
        List<Credito> ObtenerTodosCreditosDeCuenta(string NumeroCuenta);
    }
}
