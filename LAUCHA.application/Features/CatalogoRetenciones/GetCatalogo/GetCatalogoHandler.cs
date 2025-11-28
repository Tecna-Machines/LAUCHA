namespace LAUCHA.application.Features.CatalogoRetenciones.GetCatalogo
{
    internal class GetCatalogoHandler : IGetCatalogo
    {
        private readonly ICatalogoRetencionRepository _catalogo;

        public GetCatalogoHandler(ICatalogoRetencionRepository catalogo)
        {
            _catalogo = catalogo;
        }

        public async Task<Result<CatalogoRetencionesResponse>> Get()
        {
            var retenciones = await _catalogo.GetCatalogo();

            var responses = retenciones.Select(Map).ToList();

            return Result.Success(new CatalogoRetencionesResponse(responses.Count, responses));
        }

        private RetencionResponse Map(CatalogoRetencion r) =>
            new(r.Codigo, r.Concepto, r.Unidades, r.EsPorcentual, r.PrimeraQuincena);
    }
}
