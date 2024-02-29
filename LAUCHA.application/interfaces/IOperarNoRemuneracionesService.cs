using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IOperarNoRemuneracionesService
    {
        NoRemuneracionDTO CrearNuevaNoRemuneracion(CrearNoRemuneracionDTO nuevaNoRemuneracion);
        NoRemuneracionDTO CosultarUnaNoRemuneracion(string codigoNoRemuneracion);

        Task<PaginaDTO<NoRemuneracionDTO>> ConsultarNoRemuneraciones(string? cuenta,
                                                                                DateTime? desde,
                                                                                DateTime? hasta,
                                                                                string? orden,
                                                                                string? descripcion,
                                                                                int index,
                                                                                int cantidadRegistros);
    }
}
