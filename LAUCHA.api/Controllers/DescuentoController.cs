using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
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

        [HttpGet("{codigoDescuento}")]
        [ProducesResponseType(typeof(DescuentoDTO),200)]
        public IActionResult ObtenrUnDescuento(string codigoDescuento)
        {
            var result = _DescuentoService.ConsultarUnDescuento(codigoDescuento);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginaDTO<DescuentoDTO>),200)]
        public async Task<IActionResult> ConsularDescuentos(string? numeroCuenta,
                                                string? descripcion,
                                                int? cantidad,
                                                DateTime? desde,
                                                DateTime? hasta,
                                                int? pagina,
                                                string? orden = "DESC")
        {
            int cantidadReg = cantidad ?? 10;
            int indice = pagina ?? 1;

            var result = await _DescuentoService.ConsultarDescuentosFiltrados(numeroCuenta, desde, hasta, orden, descripcion, indice, cantidadReg);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
