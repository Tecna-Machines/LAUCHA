namespace LAUCHA.application.Features.Creditos.GetCredito
{
    public record GetCreditoResponse(string Codigo,
                                    string Descripcion,
                                    DateTime Creacion,
                                    string DniEmpleado,
                                    string NombreApellido,
                                    IEnumerable<CuotaResponse> Cuotas);

    public record CuotaResponse(string Nro,
                                string Descripcion,
                                decimal Monto,
                                DateTime Creacion,
                                QuincenaCuota Quincena,
                                PagoCuota? Pago);

    public record QuincenaCuota(int Quincena,int Mes,int Anio);

    public record PagoCuota(DateTime Fecha, string CodigoLiquidacion, int NroItem);

}
