using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.CalculadoraSueldos
{
    internal class CalculadoraMensualFijo : BaseCalculadoraSueldo
    {

        public override List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta)
        {
            decimal montoFijoContrato = contrato.MontoFijo;
            decimal montoBancoBruto;
            decimal montoEfectivoBruto;

            AcuerdoBlancoDTO acuerdoBlanco = contrato.AcuerdoBlanco;
            bool blancoEsPorcentual = acuerdoBlanco.EsPorcentual;


            montoBancoBruto = _CalculadoraPorcentaje.
                               CalcularPorcentajeSiEstaHabilitado(blancoEsPorcentual, acuerdoBlanco.Cantidad, montoFijoContrato);

            montoEfectivoBruto = montoFijoContrato - montoBancoBruto;

            var remuBlanco = new RemuneracionDTO
            {
                Descripcion = "sueldo mensual fijo bruto en banco",
                EsBlanco = true,
                Cuenta = cuenta.NumeroCuenta,
                Monto = montoBancoBruto
            };

            var remuNegro = new RemuneracionDTO
            {
                Descripcion = "sueldo mensual fijo bruto en efectivo",
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
                decimal montoRetencion;
                bool esRetencionPorcentual = retencion.EsPorcentual;

                montoRetencion = _CalculadoraPorcentaje.
                                 CalcularPorcentajeSiEstaHabilitado(esRetencionPorcentual, retencion.Unidades, montoBrutoBlanco);



                var nuevoRetencion = this.CrearRetencion(retencion, montoRetencion, indice++, cuenta.NumeroCuenta);
                retencionesSueldo.Add(nuevoRetencion);
            }

            return retencionesSueldo;
        }

    }
}
