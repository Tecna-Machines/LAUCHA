namespace LAUCHA.application.Features.Liquidaciones
{
    public static class LiquidacionErrors
    {
        public static readonly Error Existente = new("Liquidacion.ya.existe");
        public static readonly Error NoExistente = new("Liquidacion.no.existe");
        public static readonly Error Sellada = new("Liquidacion.esta.sellada");
        public static readonly Error NoItem = new("Liquidacion.sin.item");

    }
}
