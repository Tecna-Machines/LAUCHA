namespace LAUCHA.application.Helpers
{
    internal static class CalculadorDePorcentaje
    {
        public static decimal CalcularPorcentajeDeMonto(decimal porcentaje, decimal montoTotal)
        {
            decimal unPorCiento = montoTotal / 100;
            return unPorCiento * porcentaje;
        }

        public static decimal AumentarSegunPorcentaje(decimal porcentajeIncrementar, decimal montoOriginal)
        {
            // Calcular el incremento
            decimal incremento = montoOriginal * (porcentajeIncrementar / 100);

            // Sumar el incremento al monto original
            decimal nuevoMonto = montoOriginal + incremento;

            return nuevoMonto;
        }

        public static decimal CalcularPorcentajeSiEstaHabilitado(bool esPorcentual, decimal unidades, decimal montoTotal)
        {
            if (esPorcentual)
            {
                decimal unPorCiento = montoTotal / 100;
                return unPorCiento * unidades;
            }

            return unidades;
        }
    }
}
