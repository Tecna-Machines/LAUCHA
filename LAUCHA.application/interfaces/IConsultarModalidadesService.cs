using LAUCHA.application.DTOs.ModalidadDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarModalidadesService
    {
        List<ModalidadDTO> ObtenerTodasLasModalidades();
    }
}
