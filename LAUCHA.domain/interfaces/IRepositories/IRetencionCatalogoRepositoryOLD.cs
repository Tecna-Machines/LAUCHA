using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IRetencionCatalogoRepositoryOLD
    {
        Task<PaginaRegistro<RetencionOLD>> ObtenerRetencionesFiltradas(string? numeroCuenta,
                                                          DateTime? desde,
                                                          DateTime? hasta,
                                                          string? orden,
                                                          string? descripcion,
                                                          int numeroPagina,
                                                          int cantidadRegistros);

        List<RetencionOLD> ObtenerRetencionesDeLiquidacion(string codigoLiquidacion);
    }
}
