using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IOperarRetencionService
    {
        RetencionDTO CrearRetencion(CrearRetencionDTO nuevaRetencionDTO);
        RetencionDTO ConsultarRetencion(string codigoRetencion);
        Task<PaginaDTO<RetencionDTO>> ObtenerRetenciones(string? numeroCuenta,
                                                              DateTime? desde,
                                                              DateTime? hasta,
                                                              string? orden,
                                                              string? descripcion,
                                                              int indexPagina,
                                                              int cantidadRegistros);
    }
}
