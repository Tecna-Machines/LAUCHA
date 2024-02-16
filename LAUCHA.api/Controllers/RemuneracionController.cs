using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RemuneracionController : ControllerBase
    {
        private readonly ICrearRemuneracionService _CrearRemuneracionService;
        private readonly IConsultarRemuneracionService _ConsultarRemuneracionService;

        public RemuneracionController(ICrearRemuneracionService crearRemuneracionService, 
                                      IConsultarRemuneracionService consultarRemuneracionService)
        {
            _CrearRemuneracionService = crearRemuneracionService;
            _ConsultarRemuneracionService = consultarRemuneracionService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RemuneracionDTO), 201)]
        public IActionResult CargarNuevaRemuneracion(CrearRemuneracionDTO nuevaRemuneracion)
        {
            var result = _CrearRemuneracionService.CrearNuevaRemuneracion(nuevaRemuneracion);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RemuneracionDTO), 200)]
        public IActionResult ObtenerRemuneracion(string id)
        {
            var result = _ConsultarRemuneracionService.ConsultarRemuneracion(id);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginaDTO<RemuneracionDTO>), 200)]
        public async Task<IActionResult> ObtenerRemuneracionesFiltradas(string? numeroCuenta,
                                                                        string? descripcion,
                                                                        int? cantidad,
                                                                        DateTime? desde,
                                                                        DateTime? hasta,
                                                                        int? pagina,
                                                                        string? orden = "DESC")
        {
            int cantidadRegistros = cantidad ?? 10;
            int indice = pagina ?? 1;

            var result = await _ConsultarRemuneracionService.ConsultarRemuneracionesFiltradas(numeroCuenta,descripcion,
                                                                                             desde,hasta,orden, indice,cantidadRegistros);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
