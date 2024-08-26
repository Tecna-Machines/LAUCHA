using Humanizer;

namespace LAUCHA.application.Helpers
{
    internal class ConvertidorNumeroEnPalabra
    {
        public string ConvertirDecimalPalabra(decimal numeroDecimal)
        {
            int parteEntera = (int)numeroDecimal;
            string parteEnteraText = parteEntera.ToWords();

            decimal parteDecimal = numeroDecimal - parteEntera;
            string parteDecimalText = ObtenerParteDecimalEnTexto(parteDecimal);

            return $"{parteEnteraText} con {parteDecimalText} centavos";
        }

        private string ObtenerParteDecimalEnTexto(decimal parteDecimal)
        {
            // Convertir la parte decimal a centavos
            parteDecimal = decimal.Round(parteDecimal * 100);
            int parteDecimalEntera = (int)parteDecimal;

            return parteDecimalEntera.ToWords();
        }
    }
}
