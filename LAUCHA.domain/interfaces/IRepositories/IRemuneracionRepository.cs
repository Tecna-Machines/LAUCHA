using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IRemuneracionRepository
    {
        Task<PaginaRegistro<Remuneracion>> ObtenerRemuneracionesFiltradas(string? numeroCuenta,
                                                                          DateTime? desde,
                                                                          DateTime? hasta,
                                                                          string? orden,
                                                                          string? descripcion,
                                                                          int numeroPagina,
                                                                          int cantidadRegistros);

        List<Remuneracion> ObtenerRemuneracionesDeLiquidacion(string codigoLiquidacion);

    }
}
