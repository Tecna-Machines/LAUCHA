namespace LAUCHA.application.Integrations.SysContab
{
    public record RegistrarPagoContab();

    public interface IContabilidadService
    {
        Task RegistrarPagoEnContabilidad(RegistrarPagoContab req);
    }
}
