namespace LAUCHA.application.Features.Feriados.CrearFeriado
{
    public record CrearFeriadoRequest(DateTime Fecha, string Descripcion, bool EsPermanente);

    public record CrearFeriadoResponse(DateTime Fecha,
                                       string Descripcion,
                                       bool EsPermanente) :
                                        CrearFeriadoRequest(Fecha, Descripcion, EsPermanente);
}
