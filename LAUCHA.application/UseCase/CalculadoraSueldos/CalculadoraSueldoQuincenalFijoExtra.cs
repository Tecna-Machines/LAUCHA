using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
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
                    string mensaje = " 1ra quincena";
                    var nuevoRetencion = CrearRetencion(retencion.Concepto + mensaje, montoRetencion, indice++, cuenta.NumeroCuenta);
                    retencionesSueldo.Add(nuevoRetencion);
                }

                if (!EsPrimeraQuicena() && !retencion.EsQuincenal)
                {
                    //aplicar retenciones 2da quincena
                    string mensaje = " 2da quincena";
                    var nuevoRetencion = CrearRetencion(retencion.Concepto + mensaje, montoRetencion, indice++, cuenta.NumeroCuenta);
                    retencionesSueldo.Add(nuevoRetencion);
                }

            }

            return retencionesSueldo;
        }

        public override List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta)
        {
            HorasPeriodo horasTrabajo = _MarcasService.ConsularHorasPeriodo(contrato.Dni, desde, hasta);

            decimal cantidadHorasExtra = horasTrabajo.HorasExtraTotales;
            decimal montoHorasExtra = cantidadHorasExtra * (contrato.MontoHora * (decimal)1.5);
            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;

            montoBancoBruto = _CalculadoraPorcentaje.
                                CalcularPorcentajeSiEstaHabilitado(blancoEsPorcentual, acuerdoBlanco.Cantidad, montoFijoContrato);

            montoBancoBruto = (montoBancoBruto / 2);

            montoEfectivoBruto = (montoFijoContrato / 2) - montoBancoBruto;

            bool quincena = EsPrimeraQuicena();
            string mensajeQuicena = quincena == true ? "1ra QUINCENA" : "2da QUINCENA";

            var remuBlanco = new RemuneracionDTO
            {
                Descripcion = $"SUELDO {mensajeQuicena} FIJO FORMAL",
                EsBlanco = true,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoBancoBruto
            };

            var remuNegro = new RemuneracionDTO
            {
                Descripcion = $"SUELDO {mensajeQuicena} FIJO INFORMAL",
                EsBlanco = false,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoEfectivoBruto
            };

            var remuHorasExtra = new RemuneracionDTO
            {
                Descripcion = $"SUELDO HORAS EXTRA: ({cantidadHorasExtra}) HS COMPUTADAS",
                EsBlanco = false,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoHorasExtra
            };

            Remuneracion remuneracionBlanco = _MapperRemuneracion.GenerarRemuneracion(remuBlanco);
            Remuneracion remuneracionNegro = _MapperRemuneracion.GenerarRemuneracion(remuNegro);
            Remuneracion remuneracionHorasExtra = _MapperRemuneracion.GenerarRemuneracion(remuHorasExtra);

            return new List<Remuneracion> { remuneracionBlanco, remuneracionNegro, remuneracionHorasExtra };
        }
    }
}
