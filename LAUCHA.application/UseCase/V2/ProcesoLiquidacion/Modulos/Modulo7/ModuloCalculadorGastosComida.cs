using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.Mappers;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;
using LAUCHA.domain.Enums;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo7
{
    public class ModuloCalculadorGastosComida : IModuloLiquidador
    {
        private readonly IMenuesService _menuService;

        public ModuloCalculadorGastosComida(IMenuesService menuService)
        {
            _menuService = menuService;
        }

        public async Task EjecutarRutina(LiquidacionPayload payload)
        {

            bool esSegundaQuincena = payload.periodoliquidar.Inicio.Day > 15;

            if (esSegundaQuincena)
            {
                var descuentoComida = await this.RecuperarGastosComida(payload.Empleado, payload.periodoliquidar);

                payload.descuentosLiquidacion.Add(descuentoComida);
            }

        }

        private async Task<Descuento> RecuperarGastosComida(EmpleadoDTO emp, PeriodoDTO periodo)
        {
            var fechaInicio = periodo.Inicio;
            var primerDiaMes = new DateTime(fechaInicio.Year, fechaInicio.Month, 1);
            var ultimoDiaMes = new DateTime(fechaInicio.Year, fechaInicio.Month, DateTime.DaysInMonth(fechaInicio.Year, fechaInicio.Month));

            var costosComida = await _menuService.ObtenerGastosComida(dniEmpleado: emp.Dni,
                                                                      inicioPeriodo: primerDiaMes,
                                                                      finPeriodo: ultimoDiaMes);


            var descuentoComidaDTO = new CrearDescuentoDTO
            {
                Descripcion = $"comida: ({costosComida.cantidadPedidos}) pedidos dentro del mes {fechaInicio.ToString("MMMM")}",
                Monto = (costosComida.costoTotal - costosComida.descuento),
                NumeroCuenta = emp.NumeroCuenta,
                NumeroConcepto = null
            };

            return new DescuentoMapper().CrearDescuento(descuentoComidaDTO);
        }
    }
}
