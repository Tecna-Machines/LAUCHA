using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IContratoRepository
    {
        Contrato ObtenerContratoDeEmpleado(string dniEmpleado);
        List<Contrato> ObtenerContratosDeEmpleado(string dniEmpleado);
    }
}
