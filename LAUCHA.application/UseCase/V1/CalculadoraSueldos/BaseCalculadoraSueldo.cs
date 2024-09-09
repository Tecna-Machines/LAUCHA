using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V1.CalculadoraSueldos
{
    internal abstract class BaseCalculadoraSueldo : IEstrategiaCalcularSueldo
    {
        protected RetencionMapper _MapperRetencion;
        protected CalculadorDePorcentaje _CalculadoraPorcentaje;
        protected RemuneracionMapper _MapperRemuneracion;


        public BaseCalculadoraSueldo()
        {
            _MapperRetencion = new();
            _CalculadoraPorcentaje = new();
            _MapperRemuneracion = new();
        }

        protected bool EsPrimeraQuincena()
        {
            return DateTime.Now.Day < 15;
        }

        protected Retencion CrearRetencion(RetencionFijaDTO retencionFija, decimal monto, int indice, string numeroCuenta)
        {
            string simbolo = retencionFija.EsPorcentual == true ? "%" : "$";
            string descripcionRetencion = $"{retencionFija.Concepto} {simbolo}({retencionFija.Unidades})";

            var retencionDTO = new CrearRetencionDTO
            {
                Descripcion = descripcionRetencion,
                Monto = monto,
                NumeroCuenta = numeroCuenta
            };

            var retencion = _MapperRetencion.GenerarRetencion(retencionDTO);

            retencion.CodigoRetencion = retencion.CodigoRetencion + indice;

            return retencion;
        }

        protected bool EsPrimeraQuicena()
        {
            return DateTime.Now.Day < 15;
        }

        public abstract List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta);
        public abstract List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuenta);
    }
}
