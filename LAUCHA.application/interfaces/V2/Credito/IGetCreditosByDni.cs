using LAUCHA.application.DTOs.CreditoDTOs;

namespace LAUCHA.application.interfaces.V2.Credito
{
    public interface IGetCreditosByDni
    {
        List<CreditoDTO> ObtenerCreditosDeUnEmpleado(string dni);
    }
}
