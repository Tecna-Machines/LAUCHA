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
    }
}
