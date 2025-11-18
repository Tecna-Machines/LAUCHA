using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.CatalogoRetenciones.GetCatalogo
{
    public interface IGetCatalogo
    {
        Task<Result<CatalogoRetencionesResponse>> Get();
    }
}
