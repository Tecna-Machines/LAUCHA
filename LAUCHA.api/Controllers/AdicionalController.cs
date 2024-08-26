using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdicionalController : ControllerBase
    {
        private readonly ICrearAdicionalService _crearAdicionalService;
        private readonly IConsultarAdicionalesService _consultarAdicionalesService;

        public AdicionalController(ICrearAdicionalService crearAdicionalService, IConsultarAdicionalesService consultarAdicionalesService)
        {
            _crearAdicionalService = crearAdicionalService;
            _consultarAdicionalesService = consultarAdicionalesService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AdicionalDTO), 201)]
        public IActionResult CrearUnNuevoAdicional(AdicionalDTO nuevoAdicional)
        {
            var result = _crearAdicionalService.CrearNuevoAdicional(nuevoAdicional);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{codigoAdicional}")]
        [ProducesResponseType(typeof(AdicionalDTO), 200)]
        public IActionResult ObtenerUnAdicional(string codigoAdicional)
        {
            var result = _consultarAdicionalesService.ObtenerAdicionalPorCodigo(codigoAdicional);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AdicionalDTO>), 200)]
        public IActionResult ObtenerTodosLosAdicionales()
        {
            var result = _consultarAdicionalesService.ObtenerTodosLosAdicionales();
            return new JsonResult(result) { StatusCode = 200 };
        }

    }
}
