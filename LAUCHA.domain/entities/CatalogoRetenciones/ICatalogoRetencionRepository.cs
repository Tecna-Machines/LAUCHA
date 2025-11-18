namespace LAUCHA.domain.Entities.RetencionesCatalogo
{
    public interface ICatalogoRetencionRepository
    {
        Task<IEnumerable<CatalogoRetencion>> GetCatalogo();
        Task<CatalogoRetencion?> GetRetencion(string codigo);
        Task<CatalogoRetencion> Insert(CatalogoRetencion retencionCatalogo);
    }
}
