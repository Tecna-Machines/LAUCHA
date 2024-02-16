using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarRemuneracionService
    {
        RemuneracionDTO ConsultarRemuneracion(string codigoRemuneracion);

        Task<PaginaDTO<RemuneracionDTO>> ConsultarRemuneracionesFiltradas(string? numeroCuenta,
                                                                     string? descripcion,
                                                                     DateTime? desde,
                                                                     DateTime? hasta,
                                                                     string? orden,
                                                                     int indexPagina,
                                                                     int cantidad);
    }
}
