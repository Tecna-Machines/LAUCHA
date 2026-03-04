namespace LAUCHA.application.Features.Feriados.GetFeriadoMes
{
    public record GetFeriadoResponse(DateTime Fecha, string Descripcion, bool SeRepite);

    public record GetFeriadosMesResponse(IEnumerable<GetFeriadoResponse> Feriados);

}
