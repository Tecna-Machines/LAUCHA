using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IOperarDescuentosService
    {
        DescuentoDTO CrearUnDescuentoNuevo(CrearDescuentoDTO nuevoDescuentoDTO);
        DescuentoDTO ConsultarUnDescuento(string codigo);

        Task<PaginaDTO<DescuentoDTO>> ConsultarDescuentosFiltrados(string? cuenta,
                                                                                DateTime? desde,
                                                                                DateTime? hasta,
                                                                                string? orden,
                                                                                string? descripcion,
                                                                                int index,
                                                                                int cantidadRegistros);
    }
}
