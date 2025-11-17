using LAUCHA.domain.entities;
using LAUCHA.domain.Entities.Liquidaciones;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface ILiquidacionRepositoryOLD
    {
        Task<PaginaRegistro<Liquidacion>> ConseguirLiquidacionesFiltradas(FiltroLiquidacion filtros, int indice, int cantidadRegistros);
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
