using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IAdicionalesPorContratoRepository
    {
        List<AdicionalPorContrato> ObtenerAdicionalesSegunContrato(string codigoContrato);
    }
}
