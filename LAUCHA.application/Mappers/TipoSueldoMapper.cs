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
            if (tipo == TipoSueldo.MensualFijo) return "Mensual";
            if (tipo == TipoSueldo.QuincenalFijoMasExtras) return "Quincenal hora";
            if (tipo == TipoSueldo.QuincenalFijo) return "Quincenal fijo";
            if (tipo == TipoSueldo.MensualFijoMasExtra) return "Mensual fijo mas extra";

            return "error";
        }
    }
}
