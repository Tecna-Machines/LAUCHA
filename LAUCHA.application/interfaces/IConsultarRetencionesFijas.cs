using LAUCHA.application.DTOs.RetencionesFijasDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarRetencionesFijasService
    {
        RetencionFijaConHistorialDTO ConsultarUnaRetencionFija(string codigoRetencion);
        List<RetencionFijaDTO> ConsultarRetencionesFijas();
    }
}
