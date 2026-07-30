using LAUCHA.application.Mappers;

namespace LAUCHA.application.Features.Liquidaciones.CrearItem
{
    internal class FabricaItem : IFabricaItem
    {
        public ItemLiquidacion Crear(CrearItemRequest reqItem)
        {

            if (reqItem.EsEnBlanco)
                return CrearItemEnBlanco(reqItem);

            return CrearItemEnNegro(reqItem);
        }

        private ItemLiquidacion CrearItemEnBlanco(CrearItemRequest req)
        {
            switch (TipoItemLiquidacionMapper.ToTipoItem(req.Tipo))
            {
                case (TipoItemLiquidacion.Remunerativo):
                    return ItemLiquidacion.CrearRemunerativo(req.Concepto, req.Monto);

                case (TipoItemLiquidacion.NoRemunerativo):
                    return ItemLiquidacion.CrearNoRemunerativo(req.Concepto, req.Monto);

                case (TipoItemLiquidacion.Retencion):
                    return ItemLiquidacion.CrearRetencion(req.Concepto, req.Monto);
                case (TipoItemLiquidacion.Descuento):
                    return ItemLiquidacion.CrearRetencion(req.Concepto, req.Monto);
                default:
                    throw new InvalidCastException("invalid.tipo");

            }
        }

        private ItemLiquidacion CrearItemEnNegro(CrearItemRequest req)
        {
            switch (TipoItemLiquidacionMapper.ToTipoItem(req.Tipo))
            {
                case (TipoItemLiquidacion.Remunerativo):
                    return ItemLiquidacion.CrearRemunerativoInterno(req.Concepto, req.Monto);

                case TipoItemLiquidacion.NoRemunerativo:
                    throw new InvalidCastException("No se permiten items no remunerativos en negro.");

                case (TipoItemLiquidacion.Descuento):
                    return ItemLiquidacion.CrearDescuentoInterno(req.Concepto, req.Monto);

                default:
                    throw new InvalidCastException("invalid.tipo");

            }
        }
    }
}
