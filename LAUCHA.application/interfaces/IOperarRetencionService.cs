using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IOperarRetencionService
    {
        RetencionDTO CrearRetencion(CrearRetencionDTO nuevaRetencionDTO);

        Task<PaginaDTO<RetencionDTO>> ObtenerRetenciones(string? numeroCuenta,
                                                              DateTime? desde,
                                                              DateTime? hasta,
                                                              string? orden,
                                                              string? descripcion,
                                                              int indexPagina,
                                                              int cantidadRegistros);
    }
}
