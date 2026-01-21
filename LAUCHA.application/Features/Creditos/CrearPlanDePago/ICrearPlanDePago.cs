namespace LAUCHA.application.Features.Creditos.CrearPlanDePago
{
    public interface ICrearPlanDePago
    {
        Task<Result<CrearPlanDePagoResponse>> Crear(string codigoCredito, CrearPlanDePagoRequest req);
    }
}
