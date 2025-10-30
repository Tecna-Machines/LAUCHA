using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IContratoRepository
    {
        Acuerdo ObtenerContratoDeEmpleado(string dniEmpleado);
        List<Acuerdo> ObtenerContratosDeEmpleado(string dniEmpleado);
    }
}
