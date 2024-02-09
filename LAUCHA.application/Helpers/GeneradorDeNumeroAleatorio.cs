using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.Helpers
{
    internal class GeneradorDeNumeroAleatorio
    {
        public int GenerarAleatorioEntreValores(int valorMinimo,int valorMaximo)
        {
            if (valorMinimo >= valorMaximo)
            {
                throw new ArgumentException("El valor mínimo debe ser menor que el valor máximo.");
            }

            Random random = new Random();
            return random.Next(valorMinimo, valorMaximo + 1);
        }
    }
}
