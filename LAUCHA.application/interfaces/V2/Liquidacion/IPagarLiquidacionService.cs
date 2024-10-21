using LAUCHA.application.DTOs.LiquidacionDTOs;

namespace LAUCHA.application.interfaces.V2.Liquidacion
{
    public interface IPagarLiquidacionService
    {
        PagoDTO CrearPagoLiquidacion(CrearPagoLiquidacionDTO pago);
    }
}
