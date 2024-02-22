using LAUCHA.application.interfaces;
using LAUCHA.domain.Enums;
using LAUCHA.domain.interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    public class FabricaCalculadoraSueldo : IFabricaCalculadoraSueldo
    {
        private readonly IMarcasService _MarcasService;

        public FabricaCalculadoraSueldo(IMarcasService marcasService)
        {
            _MarcasService = marcasService;
        }

        public IEstrategiaCalcularSueldo CrearCalculadoraSueldo(int modalidadContrato)
        {
            switch (modalidadContrato)
            {
                case (int)ModalidadContrato.mensualFijo:
                    return new CalculadoraMensualFijo();
                case (int)ModalidadContrato.quincenalFijo:
                    return new CalculadoraQuicenalFijo();
                case (int)ModalidadContrato.quincenalHora:
                    return new CalculadoraQuincenalHora(_MarcasService);
                case (int)ModalidadContrato.mensualFijoHorasExtra:
                    return new CalculadoraMensualFijoExtra(_MarcasService);
                case (int)ModalidadContrato.quincenalFijoExtra:
                    return new CalculadoraSueldoQuincenalFijoExtra(_MarcasService);
                default:
                    throw new NotImplementedException("no se calcular eso! D:");
            }
        }
    }
}
