using LAUCHA.application.DTOs.RetencionesFijasDTOs;

namespace LAUCHA.application.interfaces
{
    public interface ICrearRetencionesFijasService
    {
        RetencionFijaDTO CrearNuevaRetencionFija(RetencionFijaDTO nuevaRetencionFija);
    }
}
