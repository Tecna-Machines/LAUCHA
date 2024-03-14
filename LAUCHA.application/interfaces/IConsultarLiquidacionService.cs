using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarLiquidacionService
    {
        LiquidacionDTO ConsulatarLiquidacion(string codigoLiquidacion);
        Task<PaginaDTO<LiquidacionResumenDTO>> ConsultarLiquidaciones(FiltroLiquidacion filtros, int indice, int cantidadRegistros);
    }
}
