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

        public CreditoController(ICreadorCreditos crearCreditoService)
        {
            _CrearCreditoService = crearCreditoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreditoDTO), 200)]
        public IActionResult CrearUnNuevoCredito(CrearCreditoDTO nuevoCredito)
        {
            var result = _CrearCreditoService.CrearNuevoCredito(nuevoCredito);

            return new JsonResult(result) { StatusCode = 201 };
        }
    }
}
