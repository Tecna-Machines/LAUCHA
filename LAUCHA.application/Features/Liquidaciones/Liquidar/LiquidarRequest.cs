namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public sealed record LiquidarRequest(string Codigo);
    public sealed record LiquidarResponse(string Codigo, int CantidadItems);
}
