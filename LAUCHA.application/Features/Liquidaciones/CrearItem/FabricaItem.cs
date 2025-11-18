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
                    return ItemLiquidacion.CrearItemRemunerativo(req.Concepto, req.Monto);

                case (TipoItemLiquidacion.NoRemunerativo):
                    return ItemLiquidacion.CrearItemNoRemunerativo(req.Concepto, req.Monto);

                case (TipoItemLiquidacion.Descuento):
                    return ItemLiquidacion.CrearDescuento(req.Concepto, req.Monto);

                default:
                    throw new InvalidCastException("invalid.tipo");

            }
        }

        private ItemLiquidacion CrearItemEnNegro(CrearItemRequest req)
        {
            switch (TipoItemLiquidacionMapper.ToTipoItem(req.Tipo))
            {
                case (TipoItemLiquidacion.Remunerativo):
                    return ItemLiquidacion.CrearRemuneracionEnNegro(req.Concepto, req.Monto);

                case TipoItemLiquidacion.NoRemunerativo:
                    throw new InvalidCastException("No se permiten items no remunerativos en negro.");

                case (TipoItemLiquidacion.Descuento):
                    return ItemLiquidacion.CrearDescuentoEnNegro(req.Concepto, req.Monto);

                default:
                    throw new InvalidCastException("invalid.tipo");

            }
        }
    }
}
