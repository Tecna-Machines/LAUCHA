using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LiquidacionController : ControllerBase
    {
        private readonly ILiquidacionService _liquidacionService;
        private readonly IConsultarEmpleadoService _empleadoService;
        private readonly IAgregarCuentaService _CuentaService;
        private readonly IConsultarContratoTrabajoService _ContratoService;
        public LiquidacionController(ILiquidacionService liquidacionService,
                                     IConsultarEmpleadoService empleadoService,
                                     IAgregarCuentaService cuentaService,
                                     IConsultarContratoTrabajoService contratoService)
        {
            _liquidacionService = liquidacionService;
            _empleadoService = empleadoService;
            _CuentaService = cuentaService;
            _ContratoService = contratoService;
        }

        [HttpPost("empleado/{dni}/deducir-retenciones")]
        [ProducesResponseType(typeof(DeduccionDTOs),201)]
        public IActionResult HacerDeducciones(string dni,DateTime desde,DateTime hasta)
        {
            var empleado = _empleadoService.ConsultarUnEmpleado(dni);

            var cuenta = _CuentaService.ConsularUnaCuenta(empleado.NumeroCuenta);
            var contrato = _ContratoService.ObtenerContratoDeEmpleado(empleado.Dni);

            _liquidacionService.SetearEmpleadoALiquidar(desde,hasta,contrato,cuenta);
            var result =_liquidacionService.HacerDeduccionesSueldo();

            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPost("empleado/{dni}/liquidar")]
        [ProducesResponseType(typeof(LiquidacionDTO),201)]
        public async Task<IActionResult> LiquidarEmpleado(string dni, DateTime desde, DateTime hasta)
        {
            var empleado = _empleadoService.ConsultarUnEmpleado(dni);

            var cuenta = _CuentaService.ConsularUnaCuenta(empleado.NumeroCuenta);
            var contrato = _ContratoService.ObtenerContratoDeEmpleado(empleado.Dni);

            _liquidacionService.SetearEmpleadoALiquidar(desde, hasta, contrato, cuenta);
            var result = await _liquidacionService.HacerUnaLiquidacion();

            return new JsonResult(result) { StatusCode = 201 };
        }
    }
}
