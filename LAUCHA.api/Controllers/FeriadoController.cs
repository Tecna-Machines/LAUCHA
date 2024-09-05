using LAUCHA.application.DTOs.DiasEspecialesDTOs.FeriadosDTO;
using LAUCHA.application.interfaces.IDiasEspecialesServices;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeriadoController : ControllerBase
    {
        private readonly ICrearConsultarFeriados _feriadoService;

        public FeriadoController(ICrearConsultarFeriados feriadoService)
        {
            _feriadoService = feriadoService;
        }

        [HttpPost]
        public IActionResult cargarFeriado(CrearFeriadoDTO feriado)
        {
            var result = _feriadoService.agregarFeriado(feriado);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{anio}")]
        public IActionResult obtenerFeriados(int? anio)
        {
            var result = _feriadoService.obtenerFeriadosAnio(anio);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
