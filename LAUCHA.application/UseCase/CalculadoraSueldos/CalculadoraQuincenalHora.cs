using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    internal class CalculadoraQuincenalHora : BaseCalculadoraSueldo
    {
        private readonly IMarcasService _MarcasService;
        private readonly GeneradorDeNumeroAleatorio _GeneradorAleatorio;
        public CalculadoraQuincenalHora(IMarcasService marcasService)
        {
            _MarcasService = marcasService;
            _GeneradorAleatorio = new();

            _MapperRemuneracion = new();
            _MapperRetencion = new();
            _CalculadoraPorcentaje = new();
        }

        public override List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta)
        {
            HorasPeriodo horasTrabajo = _MarcasService.ConsularHorasPeriodo(contrato.Dni, desde, hasta);
            decimal horasAleatorias = _GeneradorAleatorio.GenerarAleatorioEntreValores(40, 50);
            decimal horasRelales = horasTrabajo.HorasTotales;

            decimal montoBancoBruto = horasAleatorias * contrato.MontoHora;
            decimal montoEfectivoBruto = horasRelales * contrato.MontoHora;

            bool quincena = EsPrimeraQuicena();
            string mensajeQuicena = quincena == true ? "1ra quincena" : "2da quincena";

            var remuBlanco = new RemuneracionDTO
            {
                Descripcion = $"sueldo {mensajeQuicena} hora ({horasAleatorias} HS computadas)",
                EsBlanco = true,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoBancoBruto
            };

            var remuNegro = new RemuneracionDTO
            {
                Descripcion = $"sueldo {mensajeQuicena} hora ({horasRelales} HS computadas)",
                EsBlanco = false,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoEfectivoBruto
            };

            Remuneracion remuneracionBlanco = _MapperRemuneracion.GenerarRemuneracion(remuBlanco);
            Remuneracion remuneracionNegro = _MapperRemuneracion.GenerarRemuneracion(remuNegro);

            return new List<Remuneracion> { remuneracionBlanco, remuneracionNegro };

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

    }
}
