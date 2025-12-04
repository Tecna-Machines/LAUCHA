namespace LAUCHA.application.Features.Liquidaciones.GetRecibo
{
    public sealed record GetReciboLiquidacionRequest(string Id);

    public sealed record GetReciboLiquidacionResponse(string FileName, string ContentType, byte[] Content);
}
