using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.DTOs.SueldosDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    public class CalculadoraMensualFijo : IEstrategiaCalcularSueldo
    {
        private CalculadorDePorcentaje _CalculadoraPorcentaje = new();
        private RetencionMapper _MapperRetencion = new();
        private RemuneracionMapper _MapperRemuneracion = new();
        public List<Remuneracion> CalcularSueldoBruto(DateTime desde,DateTime hasta,ContratoDTO contrato,CuentaDTO cuenta)
        {
            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;


            montoBancoBruto = _CalculadoraPorcentaje.
                               CalcularPorcentajeSiEstaHabilitado(blancoEsPorcentual,acuerdoBlanco.Cantidad,montoFijoContrato);
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

            Remuneracion remuneracionBlanco = _MapperRemuneracion.GenerarRemuneracion(remuBlanco);
            Remuneracion remuneracionNegro = _MapperRemuneracion.GenerarRemuneracion(remuNegro);

            return new List<Remuneracion> { remuneracionBlanco, remuneracionNegro };
        }

        public List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuenta)
        {
            int indice = 0;

            List <RetencionFijaDTO> retencionesFijas = cuenta.Retenciones;
            List<Retencion> retencionesSueldo = new List<Retencion>();

            foreach (var retencion in retencionesFijas)
            {
                decimal montoRetencion;


                if (retencion.EsPorcentual)
                {
                    montoRetencion = _CalculadoraPorcentaje.CalcularPorcentajeDeMonto(retencion.Unidades, montoBrutoBlanco);
                }
                else
                {
                    montoRetencion = retencion.Unidades;
                }

                var nuevoRetencion = CrearRetencion(retencion.Concepto, montoRetencion, indice++,cuenta.NumeroCuenta);
                retencionesSueldo.Add(nuevoRetencion);
            }

            return retencionesSueldo;
        }

        private Retencion CrearRetencion(string descripcion, decimal monto, int indice,string numeroCuenta)
        {
            var retencionDTO = new CrearRetencionDTO
            {
                Descripcion = descripcion,
                Monto = monto,
                NumeroCuenta = numeroCuenta
            };

            var retencion = _MapperRetencion.GenerarRetencion(retencionDTO);

            retencion.CodigoRetencion = retencion.CodigoRetencion + indice;

            return retencion;
        }
    }
}
