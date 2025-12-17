namespace LAUCHA.application.Features.Creditos.CrearCredito
{
    public record CrearCreditoRequest(string Dni,
                                      decimal MontoPrestado,
                                      decimal MontoDevolver,
                                      string Descripcion,
                                      int CantidadCuotas,
                                      int ModoPago,
                                      CreditoQuincenaRequest Quincena);

    public record CreditoQuincenaRequest(int Quincena, int Mes, int Anio);

    public record CrearCreditoResponse(string Codigo, string Descripcion);
}
