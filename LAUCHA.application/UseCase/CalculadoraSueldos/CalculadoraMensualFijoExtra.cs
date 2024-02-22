using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public override List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta)
        {
            HorasPeriodo horasTrabajadas = _MarcasService.ConsularHorasPeriodo(contrato.Dni,desde,hasta);

            decimal cantidadHorasExtra = horasTrabajadas.HorasExtraTotales;

            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;

            decimal montoHorasExtra = cantidadHorasExtra * (contrato.MontoHora*(decimal)1.5);

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

            return new List<Remuneracion> { remuneracionBlanco, remuneracionNegro,remuneracionHorasExtra};
        }
    }
}
