namespace LAUCHA.application.Integrations.SysContab
{
    public record RegistrarPagoContab(string CuentaContableId,
                                      Liquidacion Liquidacion,
                                      Pago Pago);

    public interface IContabilidadService
    {
        Task RegistrarPagoEnContabilidad(RegistrarPagoContab req);
    }
}
