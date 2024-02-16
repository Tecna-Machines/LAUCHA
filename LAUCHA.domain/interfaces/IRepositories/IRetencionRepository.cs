using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IRetencionRepository
    {
        Task<PaginaRegistro<Retencion>> ObtenerRetencionesFiltradas(string? numeroCuenta,
                                                          DateTime? desde,
                                                          DateTime? hasta,
                                                          string? orden,
                                                          string? descripcion,
                                                          int numeroPagina,
                                                          int cantidadRegistros);
    }
}
