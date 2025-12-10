namespace LAUCHA.application.Features.Liquidaciones.GetRecibos
{
    public sealed record GetRecibosRequest(int Quincena, int Mes, int Anio);

    public sealed record GetRecibosResponse(string FileName, string ContentType, byte[] Content);
}
