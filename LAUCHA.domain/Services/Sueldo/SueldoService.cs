using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Liquidaciones;
using LAUCHA.domain.Enums;
using LAUCHA.domain.Services.CalendarioLaboral;

namespace LAUCHA.domain.Services.Sueldo
{
    public class SueldoService : ISueldoService
    {
        private readonly ICalendarioLaboral _calendarioLaboral;

        public SueldoService(ICalendarioLaboral calendarioLaboral)
        {
            _calendarioLaboral = calendarioLaboral;
        }

        public ItemLiquidacion ComputarInterno(Liquidacion liq)
        {
            decimal valorSueldoInterno = liq.Acuerdo.Sueldo;

            var itemSueldoInterno = (liq.Acuerdo.TipoSueldo) switch
            {
                TipoSueldo.MENSUAL_FIJO => CalcularMensualInterno(valorSueldoInterno),
                TipoSueldo.MENSUAL_FIJO_CON_HS_EXTRA => CalcularMensualInterno(valorSueldoInterno),
                TipoSueldo.QUINCENAL_FIJO => CalcularQuincenalInterno(valorSueldoInterno),
                TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA => CalcularQuincenalInterno(valorSueldoInterno),

                _ => throw new ArgumentOutOfRangeException("sueldo.invalido")
            };

            return itemSueldoInterno;
        }

        private static ItemLiquidacion CalcularQuincenalInterno(decimal sueldo)
        {
            return ItemLiquidacion.CrearRemunerativoInterno("sueldo quincenal", sueldo/ 2);
        }

        private static ItemLiquidacion CalcularMensualInterno(decimal sueldo)
        {
            return ItemLiquidacion.CrearRemunerativoInterno("sueldo mensual",sueldo);
        }

        public async Task<ItemLiquidacion> ComputarOficial(Liquidacion liq)
        {
            decimal valorJornal = liq.Acuerdo.ValorSueldoOJornal;

            var itemSueldoOficial = (liq.Acuerdo.TipoSueldo) switch
            {
                TipoSueldo.MENSUAL_FIJO => CalcularMensualOficial(valorJornal),
                TipoSueldo.MENSUAL_FIJO_CON_HS_EXTRA => CalcularMensualOficial(valorJornal),
                TipoSueldo.QUINCENAL_FIJO => await CalcularQuincenalOficial(liq),
                TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA => await CalcularQuincenalOficial(liq),

                _ => throw new ArgumentOutOfRangeException("sueldo.invalido")
            };

            return itemSueldoOficial;
        }

        public static ItemLiquidacion CalcularMensualOficial(decimal sueldoOficial)
        {
           return ItemLiquidacion.CrearRemunerativo("Sueldo Mensual",sueldoOficial);

        }

        private async Task<ItemLiquidacion> CalcularQuincenalOficial(Liquidacion liq)
        {
            decimal valorJornal = liq.Acuerdo.ValorSueldoOJornal;
            Jornada jornada = liq.Acuerdo.Jornada;
            int hsJornada = 9;
            int hsBlanco;

            if (jornada == Jornada.MEDIA)
                hsJornada = 4;

            int diaHabiles = await _calendarioLaboral.CalcularDiasHabiles(
                liq.Anio,
                liq.Mes,
                liq.Quincena);


            hsBlanco = diaHabiles * hsJornada;
            decimal montoSueldo = hsBlanco *valorJornal;

            return ItemLiquidacion.CrearRemunerativo($"Horas trabajadas ({hsBlanco})", montoSueldo);
        }
    }
}
