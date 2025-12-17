using LAUCHA.application.Features.Liquidaciones.GetRecibos;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecibosController : ControllerBase
    {
        private readonly IGetRecibos _recibos;

        public RecibosController(IGetRecibos recibos)
        {
            _recibos = recibos;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecibos([FromQuery] GetRecibosRequest req)
        {
            var result = await _recibos.Get(req);

            if (result.IsFailure)
                return Problem(result.Error.Descripcion);

            var r = result.Value;

            return File(
                fileContents: r.Content,
                contentType: r.ContentType,
                fileDownloadName: r.FileName
            );
        }
    }
}
