namespace LAUCHA.application.Features.Liquidaciones.CrearItem
{
    public record CrearItemRequest(string Concepto, decimal Monto, bool EsEnBlanco, int Tipo);

    public sealed record CrearItemResponse(string CodigoLiquidacion,
                                           int NroItem,
                                           string Concepto,
                                           decimal Monto,
                                           bool EsEnBlanco,
                                           int Tipo,
                                           DateTime Fecha);
}
