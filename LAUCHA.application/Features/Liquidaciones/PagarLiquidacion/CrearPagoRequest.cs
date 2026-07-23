namespace LAUCHA.application.Features.Liquidaciones.PagarLiquidacion
{
    public record CrearPagoRequest(string LiquidacionId,
                                   string CuentaContableId,
                                   decimal Monto,
                                   int Modo,
                                   bool EsInterno,
                                   string Descripcion);

    public record PagoCreadoResponse(string Id,
                                    string Descripcion,
                                    decimal Monto);
}
