using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Calculadoras.Sueldos
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

        protected bool EsPrimeraQuicena(DateTime fecha)
        {
            return fecha.Day < 15;
        }

        public abstract List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta);
        public abstract List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuenta);
        public  List<Retencion> CalcularRetencionesSueldo(DateTime desde,DateTime hasta,decimal montoBrutoBlanco,CuentaDTO cuenta)
        {
            {

                int indice = 0;

                List<RetencionFijaDTO> retencionesFijas = cuenta.Retenciones;
                List<Retencion> retencionesSueldo = new List<Retencion>();

                foreach (var retencion in retencionesFijas)
                {
                    decimal montoRetencion = _CalculadoraPorcentaje.
                                             CalcularPorcentajeSiEstaHabilitado(retencion.EsPorcentual, retencion.Unidades, montoBrutoBlanco);

                    if (EsPrimeraQuicena(desde) && retencion.EsQuincenal)
                    {
                        //aplicar retenciones 1ra quincena
                        var nuevoRetencion = CrearRetencion(retencion, montoRetencion, indice++, cuenta.NumeroCuenta);
                        retencionesSueldo.Add(nuevoRetencion);
                    }

                    if (!EsPrimeraQuicena(desde) && !retencion.EsQuincenal)
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
}
