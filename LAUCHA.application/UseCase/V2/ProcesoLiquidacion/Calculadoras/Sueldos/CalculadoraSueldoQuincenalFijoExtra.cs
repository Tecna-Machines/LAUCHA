using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Calculadoras.Sueldos
{
    internal class CalculadoraSueldoQuincenalFijoExtra : BaseCalculadoraSueldo
    {
        private readonly IMarcasService _MarcasService;

        public CalculadoraSueldoQuincenalFijoExtra(IMarcasService marcasService)
        {
            _MarcasService = marcasService;
        }

        public override List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuenta)
        {

            int indice = 0;

            List<RetencionFijaDTO> retencionesFijas = cuenta.Retenciones;
            List<Retencion> retencionesSueldo = new List<Retencion>();

            foreach (var retencion in retencionesFijas)
            {
                decimal montoRetencion = _CalculadoraPorcentaje.
                                         CalcularPorcentajeSiEstaHabilitado(retencion.EsPorcentual, retencion.Unidades, montoBrutoBlanco);

                if (EsPrimeraQuicena() && retencion.EsQuincenal)
                {
                    //aplicar retenciones 1ra quincena
                    var nuevoRetencion = CrearRetencion(retencion, montoRetencion, indice++, cuenta.NumeroCuenta);
                    retencionesSueldo.Add(nuevoRetencion);
                }

                if (!EsPrimeraQuicena() && !retencion.EsQuincenal)
                {
                    //aplicar retenciones 2da quincena
                    var nuevoRetencion = CrearRetencion(retencion, montoRetencion, indice++, cuenta.NumeroCuenta);
                    retencionesSueldo.Add(nuevoRetencion);
                }

            }

            return retencionesSueldo;
        }

        public override List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta)
        {
            HorasPeriodo horasTrabajo = _MarcasService.ConsularHorasPeriodo(contrato.Dni, desde, hasta);

            decimal cantidadHorasExtra = horasTrabajo.HorasExtraTotales;
            decimal cantidadHorasDoble = horasTrabajo.HorasDoble;

            decimal montoHorasExtra = cantidadHorasExtra * contrato.MontoHora * (decimal)1.5;
            decimal montoHorasDoble = cantidadHorasDoble * contrato.MontoHora * 2;
            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;

            montoBancoBruto = _CalculadoraPorcentaje.
                                CalcularPorcentajeSiEstaHabilitado(blancoEsPorcentual, acuerdoBlanco.Cantidad, montoFijoContrato);

            montoBancoBruto = montoBancoBruto / 2;

            montoEfectivoBruto = montoFijoContrato / 2 - montoBancoBruto;

            bool quincena = EsPrimeraQuicena(desde);
            string mensajeQuicena = quincena == true ? "1ra quincena" : "2da quincena";

            var remuBlanco = new RemuneracionDTO
            {
                Descripcion = $"sueldo {mensajeQuicena} fijo formal",
                EsBlanco = true,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoBancoBruto
            };

            var remuNegro = new RemuneracionDTO
            {
                Descripcion = $"sueldo {mensajeQuicena} fijo informal",
                EsBlanco = false,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoEfectivoBruto
            };

            var remuHorasExtra = new RemuneracionDTO
            {
                Descripcion = $"sueldo horas extra: ({cantidadHorasExtra}) HS computadas",
                EsBlanco = false,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoHorasExtra
            };

            var remuHorasDoble = new RemuneracionDTO
            {
                Descripcion = $"sueldo horas doble: ({cantidadHorasDoble}) HS computadas",
                EsBlanco = false,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoHorasDoble
            };

            Remuneracion remuneracionBlanco = _MapperRemuneracion.GenerarRemuneracion(remuBlanco);
            Remuneracion remuneracionNegro = _MapperRemuneracion.GenerarRemuneracion(remuNegro);
            Remuneracion remuneracionHorasExtra = _MapperRemuneracion.GenerarRemuneracion(remuHorasExtra);
            Remuneracion remuneracionHorasDoble = _MapperRemuneracion.GenerarRemuneracion(remuHorasDoble);

            return new List<Remuneracion> { remuneracionBlanco, remuneracionNegro, remuneracionHorasExtra, remuneracionHorasDoble };
        }
    }
}
