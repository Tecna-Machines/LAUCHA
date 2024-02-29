using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.domain.entities;

namespace LAUCHA.application.Mappers
{
    internal class LiquidacionMapper
    {
        private readonly RemuneracionMapper _RemuneracionMapper = new();
        private readonly RetencionMapper _RetencionMapper = new();
        private readonly DescuentoMapper _DescuentoMapper = new();
        private readonly NoRemuneracionMapper _NoRemuneracionMapper = new();
        public LiquidacionDTO GenerarLiquidacionDTO(LiquidacionPersonal liquidacion,
                                                    List<Remuneracion> remuneraciones,
                                                    List<Retencion> retenciones,
                                                    List<Descuento> descuentos,
                                                    List<NoRemuneracion> noRemuneraciones,
                                                    List<PagoLiquidacion> pagos,
                                                    Empleado empleado)
        {
            List<RemuneracionDTO> remuneracionesDTOs = new();
            List<NoRemuneracionDTO> noRemuneracionesDTOs = new();
            List<RetencionDTO> retencionesDTOs = new();
            List<DescuentoDTO> descuentosDTOs = new();
            List<PagoDTO> pagosDTOs = new();

            decimal brutoBlanco = 0;
            decimal brutoNegro = 0;
            decimal totalNoRemunerativo = 0;
            decimal totalRetenciones = 0;
            decimal totalDescuentos = 0;

            foreach (var remuneracion in remuneraciones)
            {
                var remuDTO = _RemuneracionMapper.GenerarRemuneracionDTO(remuneracion);
                remuneracionesDTOs.Add(remuDTO);

                if (remuneracion.EsBlanco)
                {
                    brutoBlanco = brutoBlanco + remuneracion.Monto;
                }
                else
                {
                    brutoNegro = brutoNegro + remuneracion.Monto;
                }
            }

            foreach (var noRemu in noRemuneraciones)
            {
                var noRemuDTO = _NoRemuneracionMapper.GenerarDtoNoRemuneracion(noRemu);
                noRemuneracionesDTOs.Add(noRemuDTO);

                totalNoRemunerativo = totalNoRemunerativo + noRemu.Monto;
            }

            foreach (var retencion in retenciones)
            {
                totalRetenciones = totalRetenciones + retencion.Monto;
                var retenDTO = _RetencionMapper.GenerarRetencionDTO(retencion);
                retencionesDTOs.Add(retenDTO);

            }

            foreach (var desc in descuentos)
            {
                totalDescuentos = totalDescuentos + desc.Monto;
                var descDTO = _DescuentoMapper.CrearDescuentoDTO(desc, null);
                descuentosDTOs.Add(descDTO);
            }

            return new LiquidacionDTO
            {
                Codigo = liquidacion.CodigoLiquidacion,
                Empleado = $"{empleado.Nombre} {empleado.Apellido}",
                Dni = empleado.Dni,
                Concepto = liquidacion.Concepto,
                Fecha = liquidacion.FechaLiquidacion,
                Periodo = new PeriodoDTO { Inicio = liquidacion.InicioPeriodo, Fin = liquidacion.FinPeriodo },
                Items = new ItemsDTO
                {
                    Remuneraciones = remuneracionesDTOs,
                    Retenciones = retencionesDTOs,
                    NoRemuneraciones = noRemuneracionesDTOs,
                    Descuentos = descuentosDTOs
                },
                TotalBrutoBanco = brutoBlanco,
                TotalBrutoEfectivo = brutoNegro,
                TotalPagarBanco = (brutoBlanco + totalNoRemunerativo) - totalRetenciones,
                TotalPagarEfectivo = (brutoNegro - totalDescuentos),
                Pagos = pagosDTOs //TODO: terminar logica para pintar pagos

            };
        }
    }
}
