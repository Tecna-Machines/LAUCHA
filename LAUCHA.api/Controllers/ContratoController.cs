using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly ICrearContratoService _crearContratoService;

        public ContratoController(ICrearContratoService crearContratoService)
        {
            _crearContratoService = crearContratoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContratoDTO), 201)]
        public IActionResult CrearUnNuevoContrato(CrearContratoDTO nuevoContrato)
        {
            var result = _crearContratoService.CrearNuevoContrato(nuevoContrato);
            return new JsonResult(result) { StatusCode = 201};
        }
    }
}
