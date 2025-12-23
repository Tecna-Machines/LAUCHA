using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Creditos.CrearCredito;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICrearCredito _crearCredito;

        public CreditoController(ICrearCredito crearCredito)
        {
            _crearCredito = crearCredito;
        }

        [HttpPost]
        public async Task<IResult> Crear(CrearCreditoRequest req)
        {
            var result = await _crearCredito.Crear(req);

            return result.Match(onSucces: () => Results.Ok(result),
                onFailure: (error) => Results.BadRequest(error));
        }
    }
}
