using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
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
        public SueldosBrutosDTO CalcularSueldoBruto(ContratoDTO contrato)
        {
            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;

            if (blancoEsPorcentual)
            {
                montoBancoBruto = _CalculadoraPorcentaje.CalcularPorcentajeDeMonto(acuerdoBlanco.Cantidad, montoFijoContrato);
            }
            else
            {
                montoBancoBruto = acuerdoBlanco.Cantidad;
            }

            montoEfectivoBruto = montoFijoContrato - montoBancoBruto;

            return new SueldosBrutosDTO { MontoEnBanco = montoBancoBruto, MontoEnEfectivo = montoEfectivoBruto };
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
