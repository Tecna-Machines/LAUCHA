using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface ILiquidacionRepository
    {
        Task<PaginaRegistro<LiquidacionPersonal>> ConseguirLiquidacionesFiltradas(FiltroLiquidacion filtros, int indice, int cantidadRegistros);
    }

    public class FiltroLiquidacion
    {
        public string? DniEmp { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public DateTime? InicioPeriodo { get; set; }
        public DateTime? FinPeriodo { get; set; }
        public string? CodigoLiquidacionGeneral { get; set; }
        public bool Orden { get; set; }
    }
}
