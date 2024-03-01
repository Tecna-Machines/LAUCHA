using LAUCHA.application.DTOs.CreditoDTOs;

namespace LAUCHA.application.interfaces
{
    public interface ICreadorCreditos
    {
        CreditoDTO CrearNuevoCredito(CrearCreditoDTO nuevoCredito);
    }
}
