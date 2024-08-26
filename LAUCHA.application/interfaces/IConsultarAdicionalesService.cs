using LAUCHA.application.DTOs.AdicionalDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarAdicionalesService
    {
        AdicionalDTO ObtenerAdicionalPorCodigo(string codigoAdicional);
        List<AdicionalDTO> ObtenerTodosLosAdicionales();
    }
}
