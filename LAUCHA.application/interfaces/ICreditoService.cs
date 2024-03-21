using LAUCHA.application.DTOs.CreditoDTOs;

namespace LAUCHA.application.interfaces
{
    public interface ICreditoService
    {
        CreditoDTO ConsularCredito(string codigoCredito);
        List<CreditoDTO> ConsultarCreditosCuenta(string numeroCuenta);
        CreditoDTO PagarUnCreditoManualmente(string codigoCredito, decimal monto);
    }
}
