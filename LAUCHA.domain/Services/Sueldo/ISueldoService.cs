using LAUCHA.domain.Entities.Liquidaciones;

namespace LAUCHA.domain.Services.Sueldo
{
    public interface ISueldoService
    {
        ItemLiquidacion ComputarInterno(Liquidacion liq);
        Task<ItemLiquidacion> ComputarOficial(Liquidacion liq);
    }
}
