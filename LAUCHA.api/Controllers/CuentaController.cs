using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly IAgregarCuentaService _cuentaService;

        public CuentaController(IAgregarCuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet("{numeroCuenta}")]
        public IActionResult ConsultarUnaCuenta(string numeroCuenta)
        {
            var result = _cuentaService.ConsularUnaCuenta(numeroCuenta);
            return new JsonResult(result) { StatusCode = 200};
        }

        [HttpPost("{numeroCuenta}/retenciones-fijas")]
        public IActionResult CrearRetencionesFijasDeCuenta(string numeroCuenta, string[] codigosRetenciones)
        {
            var result = _cuentaService.AgregarRetencionesFijas(numeroCuenta, codigosRetenciones);
            return new JsonResult(result) { StatusCode = 200 };
        }

    }
}
