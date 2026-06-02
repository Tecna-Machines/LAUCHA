namespace LAUCHA.application.Mappers
{
    internal static class TipoSueldoMapper
    {
        public static int ToInt(TipoSueldo tipo) => (int)tipo;

        public static TipoSueldo ToTipoSueldo(int value)
        {
            if (!Enum.IsDefined(typeof(TipoSueldo), value))
                throw new ArgumentOutOfRangeException(nameof(value), $"Valor no válido: {value}");
            return (TipoSueldo)value;
        }

        public static string ToString(TipoSueldo tipo)
        {
            if (tipo == TipoSueldo.MENSUAL_FIJO) return "Mensual";
            if (tipo == TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA) return "Quincenal hora";
            if (tipo == TipoSueldo.QUINCENAL_FIJO) return "Quincenal fijo";
            if (tipo == TipoSueldo.MENSUAL_FIJO_CON_HS_EXTRA) return "Mensual fijo mas extra";

            return "error";
        }
    }
}
