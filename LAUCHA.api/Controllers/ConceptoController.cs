using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConceptoController : ControllerBase
    {
        private readonly IOperarConceptosService _ConceptoService;

        public ConceptoController(IOperarConceptosService conceptoService)
        {
            _ConceptoService = conceptoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ConceptoDTO),201)]
        public IActionResult CrearUnConcepto(ConceptoDTO conceptoNuevo)
        {
            var result = _ConceptoService.CrearUnConcepto(conceptoNuevo);

            return new JsonResult(result) { StatusCode = 201};
        }

        [HttpGet("{numeroConcepto}")]
        [ProducesResponseType(typeof(ConceptoDTO), 200)]
        public IActionResult ConsultarConcepto(int numeroConcepto)
        {
            var result = _ConceptoService.ConsultarUnConcepto(numeroConcepto);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConceptoDTO>), 200)]
        public IActionResult ConsultarLosConceptos()
        {
            var result = _ConceptoService.ConsultarTodosLosConceptos();
            return new JsonResult(result) { StatusCode = 200 };
        }

    }
}
