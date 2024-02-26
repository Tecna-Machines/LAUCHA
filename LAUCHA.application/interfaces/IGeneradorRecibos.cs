using LAUCHA.application.DTOs.LiquidacionDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IGeneradorRecibos
    {
        byte[] GenerarPdfRecibo(LiquidacionDTO liquidacion);
    }
}
