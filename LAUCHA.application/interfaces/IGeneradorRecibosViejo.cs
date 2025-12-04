using LAUCHA.application.DTOs.LiquidacionDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IGeneradorRecibosViejo
    {
        byte[] GenerarPdfRecibo(LiquidacionDTO liquidacion, DateTime fechaIngreso);
    }
}
