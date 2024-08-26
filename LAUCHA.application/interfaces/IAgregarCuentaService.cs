using LAUCHA.application.DTOs.CuentaDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IAgregarCuentaService
    {
        CuentaDTO AgregarRetencionesFijas(string numeroCuenta, string[] codigosRetenciones);
        CuentaDTO ConsularUnaCuenta(string numeroCuenta);
    }
}
