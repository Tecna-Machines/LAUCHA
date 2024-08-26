using LAUCHA.domain.entities;

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

        List<Retencion> ObtenerRetencionesDeLiquidacion(string codigoLiquidacion);
    }
}
