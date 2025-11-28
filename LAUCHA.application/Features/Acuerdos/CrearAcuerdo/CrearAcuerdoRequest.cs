namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    public sealed record CrearAcuerdoRequest(string Dni,
                                             decimal Sueldo,
                                             decimal ValorBlanco,
                                             decimal ValorHora,
                                             int TipoSueldo,
                                             string Notas,
                                             string[] Retenciones,
                                             ICollection<AdicionalesRequest> Adicionales);



    public sealed record CrearAcuerdoResponse(string Codigo);

    public sealed record AdicionalesRequest(string Concepto,
                                            bool EsEnBlanco,
                                            bool EsPorcentual,
                                            decimal Monto);

    public sealed record AdicionalesResponse(string Concepto,
                                            bool EsEnBlanco,
                                            bool EsPorcentual,
                                            decimal Monto,
                                            DateTime Fecha);
}
