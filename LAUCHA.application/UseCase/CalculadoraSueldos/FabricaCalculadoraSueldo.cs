using LAUCHA.application.interfaces;
using LAUCHA.domain.Enums;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    public class FabricaCalculadoraSueldo : IFabricaCalculadoraSueldo
    {
        private readonly IMarcasService _MarcasService;
        private readonly ILogsApp log;

        public FabricaCalculadoraSueldo(IMarcasService marcasService, ILogsApp log)
        {
            _MarcasService = marcasService;
            this.log = log;
        }

        public IEstrategiaCalcularSueldo CrearCalculadoraSueldo(int modalidadContrato)
        {
            switch (modalidadContrato)
            {
                case (int)ModalidadContrato.mensualFijo:
                    log.LogInformation("se configuro la calculadora de sueldos mensuales fijos");
                    return new CalculadoraMensualFijo();

                case (int)ModalidadContrato.quincenalFijo:
                    log.LogInformation("se configuro la calculadora de sueldos quincenales fijos");
                    return new CalculadoraQuicenalFijo();

                case (int)ModalidadContrato.quincenalHora:
                    log.LogInformation("se configuro la calculadora de sueldos quincenales x hora");
                    return new CalculadoraQuincenalHora(_MarcasService);

                case (int)ModalidadContrato.mensualFijoHorasExtra:
                    log.LogInformation("se configuro la calculadora de sueldos mensuales fijos + horas extras");
                    return new CalculadoraMensualFijoExtra(_MarcasService);

                case (int)ModalidadContrato.quincenalFijoExtra:
                    log.LogInformation("se configuro la calculadora de sueldos quincenales fijos + horas extras");
                    return new CalculadoraSueldoQuincenalFijoExtra(_MarcasService);

                default:
                    log.LogError("no existe una calculadora para ese tipo de sueldo");
                    throw new NotImplementedException("no se calcular eso! D:");
            }
        }
    }
}
