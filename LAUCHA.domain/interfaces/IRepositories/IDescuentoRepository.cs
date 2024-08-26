using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IDescuentoRepository
    {
        Task<PaginaRegistro<Descuento>> ObtenerDescuentosFiltrados(string? numeroCuenta,
                                                          DateTime? desde,
                                                          DateTime? hasta,
                                                          string? orden,
                                                          string? descripcion,
                                                          int numeroPagina,
                                                          int cantidadRegistros);

        List<Descuento> ObtenerDescuentosDeLiquidacion(string codigoLiquidacion);
    }
}
