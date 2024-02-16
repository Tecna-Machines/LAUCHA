using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RetencionController : ControllerBase
    {
        private readonly IOperarRetencionService _RetencionService;

        public RetencionController(IOperarRetencionService retencionService)
        {
            _RetencionService = retencionService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RetencionDTO),201)]
        public IActionResult CrearRetencion(CrearRetencionDTO nueva)
        {
            var result = _RetencionService.CrearRetencion(nueva);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginaDTO<RetencionDTO>), 201)]
        public async Task<IActionResult> ObtenerRetenciones(string? numeroCuenta,
                                                string? descripcion,
                                                int? cantidad,
                                                DateTime? desde,
                                                DateTime? hasta,
                                                int? pagina,
                                                string? orden = "DESC")
        {
            int cantidadRegistros = cantidad ?? 10;
            int indice = pagina ?? 1;

            var result = await _RetencionService.ObtenerRetenciones(numeroCuenta, desde,
                                                              hasta, orden, descripcion, indice, cantidadRegistros);

            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RetencionDTO),200)]
        public IActionResult ObtenerUnaRetencion(string id)
        {
            var result = _RetencionService.ConsultarRetencion(id);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
