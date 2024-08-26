using LAUCHA.application.DTOs.RemuneracionDTOs;

namespace LAUCHA.application.interfaces
{
    public interface ICrearRemuneracionService
    {
        RemuneracionDTO CrearNuevaRemuneracion(CrearRemuneracionDTO nuevaRemuneracion);
    }
}
