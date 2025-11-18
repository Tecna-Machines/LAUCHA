namespace LAUCHA.application.Features.Acuerdos.GetAcuerdoById
{
    public sealed record GetAcuerdoByIdResquest(string Codigo);

    public sealed record GetAcuerdoByIdResponse(string Codigo,
                                                DateTime Fecha,
                                                decimal ValorHora,
                                                decimal ValorBlanco,
                                                decimal Sueldo,
                                                string Notas,
                                                TipoSueldoResponse TipoSueldo,
                                                EmpleadoAcuerdoResponse Empleado,
                                                IEnumerable<AdicionalAcuerdoResponse> Adicionales,
                                                IEnumerable<RetencionResponse> Retenciones
                                                );

    public sealed record TipoSueldoResponse(string Codigo, string Descripcion);
    public sealed record EmpleadoAcuerdoResponse(string Dni, string NombreCompleto);
    public sealed record AdicionalAcuerdoResponse(string Concepto, decimal Monto, bool EsPorcentual, bool EsEnBlanco);
    public sealed record RetencionResponse(string Codigo,string Concepto,bool EsPorcentual,bool EsPrimeraQuincena,decimal Unidades);
}
