using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICreadorCreditos _CrearCreditoService;
        private readonly ICreditoService _CreditoService;

        public CreditoController(ICreadorCreditos crearCreditoService, ICreditoService creditoService)
        {
            _CrearCreditoService = crearCreditoService;
            _CreditoService = creditoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreditoDTO), 200)]
        public IActionResult CrearUnNuevoCredito(CrearCreditoDTO nuevoCredito)
        {
            var result = _CrearCreditoService.CrearNuevoCredito(nuevoCredito);

            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{codigoCredito}")]
        [ProducesResponseType(typeof(CreditoDTO),200)]
        public IActionResult ConsultarCredito(string codigoCredito)
        {
            var result = _CreditoService.ConsularCredito(codigoCredito);

            return new JsonResult(result) { StatusCode = 200};
        }

        [HttpPost("{codigoCredito}/pago-manual")]
        [ProducesResponseType(typeof(CreditoDTO), 201)]
        public IActionResult CrearDescuentoManualmente(string codigoCredito, int monto)
        {
            var result = _CreditoService.PagarUnCreditoManualmente(codigoCredito, monto);
            return new JsonResult(result) { StatusCode = 201 };
        }

    }
}
