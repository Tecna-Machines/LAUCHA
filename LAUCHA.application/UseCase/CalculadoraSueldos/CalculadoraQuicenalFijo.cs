using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    internal class CalculadoraQuicenalFijo : BaseCalculadoraSueldo
    {

        public override List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta,ContratoDTO contrato, CuentaDTO cuenta)
        {
            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;

            montoBancoBruto = _CalculadoraPorcentaje.
                                CalcularPorcentajeSiEstaHabilitado(blancoEsPorcentual,acuerdoBlanco.Cantidad,montoFijoContrato);

            montoBancoBruto = (montoBancoBruto / 2);

            montoEfectivoBruto = (montoFijoContrato / 2) - montoBancoBruto;

            bool quincena = EsPrimeraQuicena();
            string mensajeQuicena = quincena == true ? "1ra quincena" : "2da quincena";

            var remuBlanco = new RemuneracionDTO
            {
                Descripcion = $"sueldo {mensajeQuicena} fijo en banco",
                EsBlanco = true,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoBancoBruto
            };

            var remuNegro = new RemuneracionDTO
            {
                Descripcion = $"sueldo {mensajeQuicena} fijo en efectivo",
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

    }
}
