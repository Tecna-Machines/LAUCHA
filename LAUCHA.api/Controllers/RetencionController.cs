using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.CatalogoRetenciones.GetCatalogo;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RetencionController : ControllerBase
    {
        private readonly IGetCatalogo _getCatalogoRetenciones;

        public RetencionController(IGetCatalogo getCatalogoRetenciones)
        {
            _getCatalogoRetenciones = getCatalogoRetenciones;
        }

        [HttpGet]
        public async Task<IResult> GetCatalogo()
        {
            var result = await _getCatalogoRetenciones.Get();

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.BadRequest(error));
        }
    }
}
