using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DescuentoController : ControllerBase
    {
        private readonly IOperarDescuentosService _DescuentoService;

        public DescuentoController(IOperarDescuentosService descuentoService)
        {
            _DescuentoService = descuentoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DescuentoDTO),201)]
        public IActionResult CrearDescuento(CrearDescuentoDTO nuevo)
        {
            var result = _DescuentoService.CrearUnDescuentoNuevo(nuevo);
            return new JsonResult(result) { StatusCode = 201 };
        }
    }
}
