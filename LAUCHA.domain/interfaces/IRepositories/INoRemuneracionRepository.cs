using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface INoRemuneracionRepository
    {
        Task<PaginaRegistro<NoRemuneracion>> ObtenerNoRemuneracionesFiltradas(string? numeroCuenta,
                                                                         DateTime? desde,
                                                                         DateTime? hasta,
                                                                         string? orden,
                                                                         string? descripcion,
                                                                         int numeroPagina,
                                                                         int cantidadRegistros);

    }
}
