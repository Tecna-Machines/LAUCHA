using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo3
{
    public class ModuloCalculadorSueldoBase : IModuloLiquidador
    {
        private readonly IFabricaCalculadoraSueldo _fabricaCalculadoraSueldo;
        private IEstrategiaCalcularSueldo? _calculadoraSueldo;

        public ModuloCalculadorSueldoBase(IFabricaCalculadoraSueldo fabricaCalculadoraSueldo)
        {
            _fabricaCalculadoraSueldo = fabricaCalculadoraSueldo;
        }

        public Task EjecutarRutina(LiquidacionPayload payload)
        {

            List<Remuneracion> remuneracionesSueldoBase = this.calcularSueldoBase(payload);

            payload.remuneracionesLiquidacion.AddRange(remuneracionesSueldoBase);

            return Task.CompletedTask;
        }

        private List<Remuneracion> calcularSueldoBase(LiquidacionPayload payload)
        {
            PeriodoDTO periodo = payload.periodoliquidar;
            CuentaDTO cuenta = payload.Cuenta;
            ContratoDTO contrato = payload.Contrato;

            int modalidadContrato = int.Parse(contrato.Modalidad.Codigo);

            var calculadora = this.configurarCalculadoraSueldoBase(modalidadContrato);

            payload.SetCalculadoraSueldo(calculadora);

            if (payload.GetCalculadoraSueldo() == null)
            {
                throw new IOException();
            }

            return calculadora.CalcularSueldoBruto(desde: periodo.Inicio,
                                                          hasta: periodo.Fin,
                                                          contrato: contrato,
                                                          cuenta: cuenta);
        }

        private IEstrategiaCalcularSueldo configurarCalculadoraSueldoBase(int modalidadContrato)
        {
            return _fabricaCalculadoraSueldo.CrearCalculadoraSueldo(modalidadContrato);
        }
    }
}
