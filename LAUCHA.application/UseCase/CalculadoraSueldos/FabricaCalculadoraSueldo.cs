using LAUCHA.application.interfaces;
using LAUCHA.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    public class FabricaCalculadoraSueldo : IFabricaCalculadoraSueldo
    {
        public IEstrategiaCalcularSueldo CrearCalculadoraSueldo(int modalidadContrato)
        {
            switch (modalidadContrato)
            {
                case (int)ModalidadContrato.mensualFijo:
                    return new CalculadoraMensualFijo();
                case (int)ModalidadContrato.quincenalFijo:
                    return new CalculadoraQuicenalFijo();
                default:
                    throw new NotImplementedException("no se calcular eso! D:");
            }
        }
    }
}
