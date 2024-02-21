using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    public class CalculadoraQuincenalHora : IEstrategiaCalcularSueldo
    {
        private readonly IMarcasService _MarcasService;
        private readonly GeneradorDeNumeroAleatorio _GeneradorAleatorio;
        private readonly RetencionMapper _MapperRetencion;
        private readonly RemuneracionMapper _MapperRemuneracion;
        private readonly CalculadorDePorcentaje _CalculadoraPorcentaje;
        public CalculadoraQuincenalHora(IMarcasService marcasService)
        {
            _MarcasService = marcasService;
            _GeneradorAleatorio = new();

            _MapperRemuneracion = new();
            _MapperRetencion = new();
            _CalculadoraPorcentaje = new();
        }

        public List<Remuneracion> CalcularSueldoBruto(DateTime desde,DateTime hasta,ContratoDTO contrato, CuentaDTO cuenta)
        {
            HorasPeriodo horasTrabajo = _MarcasService.ConsularHorasPeriodo(contrato.Dni,desde,hasta);
            decimal horasAleatorias = _GeneradorAleatorio.GenerarAleatorioEntreValores(40, 50);

            decimal montoBancoBruto = horasAleatorias * contrato.MontoHora;
            decimal montoEfectivoBruto = horasTrabajo.HorasTotales * contrato.MontoHora;

            bool quincena = EsPrimeraQuicena();
            string mensajeQuicena = quincena == true ? "1ra QUINCENA" : "2da QUINCENA";

            var remuBlanco = new RemuneracionDTO
            {
                Descripcion = $"SUELDO {mensajeQuicena} HORA ({horasAleatorias} HS computadas)",
                EsBlanco = true,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoBancoBruto
            };

            var remuNegro = new RemuneracionDTO
            {
                Descripcion = $"SUELDO {mensajeQuicena} HORA ({horasAleatorias} HS computadas)",
                EsBlanco = false,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoEfectivoBruto
            };

            Remuneracion remuneracionBlanco = _MapperRemuneracion.GenerarRemuneracion(remuBlanco);
            Remuneracion remuneracionNegro = _MapperRemuneracion.GenerarRemuneracion(remuNegro);

            return new List<Remuneracion> { remuneracionBlanco, remuneracionNegro};

        }

        public List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuenta)
        {

            int indice = 0;

            List<RetencionFijaDTO> retencionesFijas = cuenta.Retenciones;
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

        private Retencion CrearRetencion(string descripcion, decimal monto, int indice, string numeroCuenta)
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


        private bool EsPrimeraQuicena()
        {
            return DateTime.Now.Day < 15;
        }
    }
}
