using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.Mappers;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;
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

        public async void EjecutarRutina(LiquidacionPayload payload)
        {
            var descuentoComida = await this.RecuperarGastosComida(payload.Empleado, payload.periodoliquidar);
            payload.descuentosLiquidacion.Add(descuentoComida);
        }

        private async Task<Descuento> RecuperarGastosComida(EmpleadoDTO emp, PeriodoDTO periodo)
        {
            var costosComida = await _menuService.ObtenerGastosComida(dniEmpleado: emp.Dni,
                                                                      inicioPeriodo: periodo.Inicio,
                                                                      finPeriodo: periodo.Fin);


            var descuentoComidaDTO = new CrearDescuentoDTO
            {
                Descripcion = $"comida: ({costosComida.cantidadPedidos}) pedidos dentro del periodo",
                Monto = (costosComida.costoTotal - costosComida.descuento),
                NumeroCuenta = emp.NumeroCuenta,
                NumeroConcepto = null
            };

            return new DescuentoMapper().CrearDescuento(descuentoComidaDTO);
        }
    }
}
