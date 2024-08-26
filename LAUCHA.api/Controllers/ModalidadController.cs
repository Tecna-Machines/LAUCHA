using LAUCHA.application.DTOs.ModalidadDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModalidadController : ControllerBase
    {
        private readonly IConsultarModalidadesService _ConsultarModalidadService;

        public ModalidadController(IConsultarModalidadesService consultarModalidadService)
        {
            _ConsultarModalidadService = consultarModalidadService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ModalidadDTO>), 200)]
        public IActionResult ObtenerLasModalidades()
        {
            var result = _ConsultarModalidadService.ObtenerTodasLasModalidades();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
