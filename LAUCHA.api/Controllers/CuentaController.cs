using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly IAgregarCuentaService _cuentaService;
        private readonly ICreditoService _creditoService;

        public CuentaController(IAgregarCuentaService cuentaService, ICreditoService creditoService)
        {
            _cuentaService = cuentaService;
            _creditoService = creditoService;
        }

        [HttpGet("{numeroCuenta}")]
        public IActionResult ConsultarUnaCuenta(string numeroCuenta)
        {
            var result = _cuentaService.ConsularUnaCuenta(numeroCuenta);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpPost("{numeroCuenta}/retenciones-fijas")]
        public IActionResult CrearRetencionesFijasDeCuenta(string numeroCuenta, string[] codigosRetenciones)
        {
            var result = _cuentaService.AgregarRetencionesFijas(numeroCuenta, codigosRetenciones);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{numeroCuenta}/creditos")]
        [ProducesResponseType(typeof(CreditoDTO), 200)]
        public IActionResult ConsultarCreditosCuenta(string numeroCuenta)
        {
            var result = _creditoService.ConsultarCreditosCuenta(numeroCuenta);
            return new JsonResult(result) { StatusCode = 200 };
        }


    }
}
