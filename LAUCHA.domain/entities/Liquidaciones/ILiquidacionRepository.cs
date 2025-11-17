namespace LAUCHA.domain.Entities.Liquidaciones
{
    public interface ILiquidacionRepository
    {
        Task<Liquidacion?> GetById(string id);
        Task<Liquidacion> Insert(Liquidacion liq);
        Task<Liquidacion> Update(Liquidacion liq);
    }
}
