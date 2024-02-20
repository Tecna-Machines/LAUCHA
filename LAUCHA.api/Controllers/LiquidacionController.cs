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

        [HttpPost("empleado/{id}/deducir-retenciones")]
        [ProducesResponseType(typeof(DeduccionDTOs),201)]
        public IActionResult HacerDeducciones(string id,DateTime desde,DateTime hasta)
        {
            var empleado = _empleadoService.ConsultarUnEmpleado(id);

            var cuenta = _CuentaService.ConsularUnaCuenta(empleado.NumeroCuenta);
            var contrato = _ContratoService.ObtenerContratoDeEmpleado(empleado.Dni);

            _liquidacionService.SetearEmpleadoALiquidar(contrato,cuenta);
            var result =_liquidacionService.CalcularRetenciones();

            return new JsonResult(result) { StatusCode = 201 };
        }
    }
}
