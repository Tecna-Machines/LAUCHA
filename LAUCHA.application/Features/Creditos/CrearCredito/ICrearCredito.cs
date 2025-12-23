namespace LAUCHA.application.Features.Creditos.CrearCredito
{
    public interface ICrearCredito
    {
        Task<Result<CrearCreditoResponse>> Crear(CrearCreditoRequest req);
    }
}
