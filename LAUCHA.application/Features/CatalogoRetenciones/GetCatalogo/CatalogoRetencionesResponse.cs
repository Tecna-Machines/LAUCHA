namespace LAUCHA.application.Features.CatalogoRetenciones.GetCatalogo
{
    public sealed record CatalogoRetencionesResponse(int Total, IEnumerable<RetencionResponse> Items);

    public sealed record RetencionResponse(string Codigo
                                           , string Concepto,
                                            decimal Unidades,
                                            bool EsPorcentual,
                                            bool EsPrimeraQuincena);
}
