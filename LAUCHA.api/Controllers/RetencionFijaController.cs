using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RetencionFijaController : ControllerBase
    {
        private readonly ICrearRetencionesFijasService _crearRetencionesFijasService;
        private readonly IConsultarRetencionesFijasService _consultarRetencionesFijasService;
        private readonly IModificarRetencionFijaService _modificarRetencionFijaService;

        public RetencionFijaController(ICrearRetencionesFijasService crearRetencionesFijasService,
                                       IConsultarRetencionesFijasService consultarRetencionesFijasService,
                                       IModificarRetencionFijaService modificarRetencionFijaService)
        {
            _crearRetencionesFijasService = crearRetencionesFijasService;
            _consultarRetencionesFijasService = consultarRetencionesFijasService;
            _modificarRetencionFijaService = modificarRetencionFijaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RetencionFijaDTO), 201)]
        public IActionResult CrearRetencionFija(RetencionFijaDTO nuevaRetencionFija)
        {
            var result = _crearRetencionesFijasService.CrearNuevaRetencionFija(nuevaRetencionFija);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{codigoRetencionFija}")]
        [ProducesResponseType(typeof(RetencionFijaDTO), 201)]
        public IActionResult ObtenerRetencionFija(string codigoRetencionFija)
        {
            var result = _consultarRetencionesFijasService.ConsultarUnaRetencionFija(codigoRetencionFija);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RetencionFijaDTO>), 201)]
        public IActionResult ObtenerTodasLasRetencionesFijas()
        {
            var result = _consultarRetencionesFijasService.ConsultarRetencionesFijas();
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpPatch("{codigoRetencionFija}")]
        [ProducesResponseType(typeof(RetencionFijaDTO), 200)]
        public IActionResult ModificarRetencionFija(string codigoRetencionFija,ModificadorRetencionFijaDTO modificaciones)
        {
            var result = _modificarRetencionFijaService.ModificarRetencionFija(codigoRetencionFija, modificaciones);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
