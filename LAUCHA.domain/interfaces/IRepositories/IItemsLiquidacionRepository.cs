using LAUCHA.domain.entities;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IItemsLiquidacionRepository
    {
        List<Retencion> ObtenerRetencionesLiquidacion(string codigoLiquidacion);
        List<Remuneracion> ObtenerRemuneracionesLiquidacion(string codigoLiquidacion);
        List<NoRemuneracion> ObtenerNoRemuneracionesLiquidacion(string codigoLiquidacion);
        List<Descuento> ObtenerDescuentosLiquidacion(string codigoLiquidacion);
        List<PagoLiquidacion> ObtenerPagosLiquidacion(string codigoLiquidacion);
    }
}
