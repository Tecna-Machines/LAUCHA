using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    internal class CalculadoraMensualFijoExtra : BaseCalculadoraSueldo
    {
        private readonly IMarcasService _MarcasService;

        public CalculadoraMensualFijoExtra(IMarcasService marcasService)
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
                decimal montoRetencion;
                bool esRetencionPorcentual = retencion.EsPorcentual;

                montoRetencion = _CalculadoraPorcentaje.
                                 CalcularPorcentajeSiEstaHabilitado(esRetencionPorcentual, retencion.Unidades, montoBrutoBlanco);


                var nuevoRetencion = this.CrearRetencion(retencion.Concepto, montoRetencion, indice++, cuenta.NumeroCuenta);
                retencionesSueldo.Add(nuevoRetencion);
            }

            return retencionesSueldo;
        }

        public override List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta)
        {
            HorasPeriodo horasTrabajadas = _MarcasService.ConsularHorasPeriodo(contrato.Dni, desde, hasta);

            decimal cantidadHorasExtra = horasTrabajadas.HorasExtraTotales;

            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;

            decimal montoHorasExtra = cantidadHorasExtra * (contrato.MontoHora * (decimal)1.5);

            montoBancoBruto = _CalculadoraPorcentaje.
                               CalcularPorcentajeSiEstaHabilitado(blancoEsPorcentual, acuerdoBlanco.Cantidad, montoFijoContrato);

            montoEfectivoBruto = montoFijoContrato - montoBancoBruto;

            var remuBlanco = new RemuneracionDTO
            {
                Descripcion = "SUELDO MENSUAL FIJO FORMAL",
                EsBlanco = true,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoBancoBruto
            };

            var remuNegro = new RemuneracionDTO
            {
                Descripcion = "SUELDO MENSUAL FIJO INFORMAL",
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
