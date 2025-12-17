namespace LAUCHA.application.Features.Creditos.CrearCredito
{
    public interface ICrearCredito
    {
        Result<CrearCreditoResponse> Crear(CrearCreditoRequest req);
    }
}
