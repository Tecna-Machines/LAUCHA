using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Creditos.CrearCredito;
using LAUCHA.application.Features.Creditos.GetCredito;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICrearCredito _crearCredito;
        private readonly IGetCredito _getCredito;

        public CreditoController(ICrearCredito crearCredito, IGetCredito getCredito)
        {
            _crearCredito = crearCredito;
            _getCredito = getCredito;
        }

        [HttpPost]
        public async Task<IResult> Crear(CrearCreditoRequest req)
        {
            var result = await _crearCredito.Crear(req);

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.BadRequest(error));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetCredito(string id)
        {
            var result = await _getCredito.Get(id);

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.NotFound(result.Value));
        }
    }
}
