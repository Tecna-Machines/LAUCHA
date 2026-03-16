namespace LAUCHA.application.Integrations.SysContab
{
    public record CuentaContableResponse(string Id,
                                         string Nombre,
                                         string Tipo);
    public interface ICuentasContablesService
    {
        Task<Result<IEnumerable<CuentaContableResponse>>> GetCuentasContables();
    }
}
