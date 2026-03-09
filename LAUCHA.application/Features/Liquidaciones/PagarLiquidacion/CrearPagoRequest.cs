namespace LAUCHA.application.Features.Liquidaciones.PagarLiquidacion
{
    public record CrearPagoRequest(string LiquidacionId,
                                   decimal Monto,
                                   int Modo,
                                   string Descripcion);

    public record PagoCreadoResponse(string Id,
                                    string Descripcion,
                                    decimal Monto);
}
