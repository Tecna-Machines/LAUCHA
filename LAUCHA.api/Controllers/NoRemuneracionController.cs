using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoRemuneracionController : ControllerBase
    {
        private readonly IOperarNoRemuneracionesService _NoRemuneracionService;

        public NoRemuneracionController(IOperarNoRemuneracionesService noRemuneracionService)
        {
            _NoRemuneracionService = noRemuneracionService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(NoRemuneracionDTO), 201)]
        public IActionResult CrearNuevaNoRemuneracion(CrearNoRemuneracionDTO NoRemuneracion)
        {
            var result = _NoRemuneracionService.CrearNuevaNoRemuneracion(NoRemuneracion);

            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{codigoNoRemuneracion}")]
        [ProducesResponseType(typeof(NoRemuneracionDTO), 200)]
        public IActionResult ObtenerUnaNoRemuneracion(string codigoNoRemuneracion)
        {
            var result = _NoRemuneracionService.CosultarUnaNoRemuneracion(codigoNoRemuneracion);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginaDTO<NoRemuneracionDTO>), 200)]
        public async Task<IActionResult> ObtenerNoRemuneracionesFiltradas(string? numeroCuenta,
                                                                        string? descripcion,
                                                                        int? cantidad,
                                                                        DateTime? desde,
                                                                        DateTime? hasta,
                                                                        int? pagina,
                                                                        string? orden = "DESC")
        {
            int cantidadRegistros = cantidad ?? 10;
            int index = pagina ?? 1;

            var result = await _NoRemuneracionService.ConsultarNoRemuneraciones(numeroCuenta, desde, hasta, orden,
                                                                            descripcion, index, cantidadRegistros);

            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
