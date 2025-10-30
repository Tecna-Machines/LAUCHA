namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    public sealed record CrearAcuerdoRequest(string Dni,
                                             decimal Sueldo,
                                             decimal ValorBlanco, int TipoSueldo, string Notas);



    public sealed record CrearAcuerdoResponse(string Codigo);
}
