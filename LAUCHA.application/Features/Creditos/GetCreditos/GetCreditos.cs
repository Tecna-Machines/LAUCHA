namespace LAUCHA.application.Features.Creditos.GetCreditos
{
    public record GetCreditos(IEnumerable<GetCreditoResumen> Creditos);

    public record GetCreditoResumen(string Codigo,
                                    string DniEmpleado,
                                    int Cuotas,
                                    string Descripcion,
                                    decimal MontoPrestado,
                                    string Estado);
}
