namespace LAUCHA.application.Mappers
{
    internal static class TipoItemLiquidacionMapper
    {
        public static TipoItemLiquidacion ToTipoItem(int tipo)
        {
            if (tipo == 0) return TipoItemLiquidacion.Remunerativo;
            if (tipo == 1) return TipoItemLiquidacion.Descuento;
            if (tipo == 2) return TipoItemLiquidacion.NoRemunerativo;

            throw new InvalidCastException("tipo.item.invalido");
        }

        public static int ToInt(TipoItemLiquidacion tipo)
        {
            if (tipo == TipoItemLiquidacion.Remunerativo) return 0;
            if (tipo == TipoItemLiquidacion.Descuento) return 1;
            if (tipo == TipoItemLiquidacion.NoRemunerativo) return 2;

            throw new InvalidCastException("tipo.item.invalido");
        }
    }
}
