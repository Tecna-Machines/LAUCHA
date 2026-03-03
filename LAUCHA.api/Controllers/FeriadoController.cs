using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Feriados.CrearFeriado;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeriadoController : ControllerBase
    {
        private readonly ICrearFeriado _crearFeriado;

        public FeriadoController(ICrearFeriado crearFeriado)
        {
            _crearFeriado = crearFeriado;
        }

        [HttpPost]
        public async Task<IResult> CrearFeriado(CrearFeriadoRequest req)
        {
            var result = await _crearFeriado.Crear(req);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.BadRequest(error));
        }
    }
}
