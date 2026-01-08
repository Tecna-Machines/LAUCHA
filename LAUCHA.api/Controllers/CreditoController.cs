using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Creditos.CrearCredito;
using LAUCHA.application.Features.Creditos.GetCredito;
using LAUCHA.application.Features.Creditos.GetCreditos;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly ICrearCredito _crearCredito;
        private readonly IGetCredito _getCredito;
        private readonly IGetCreditos _getCreditos;

        public CreditoController(ICrearCredito crearCredito,
                                 IGetCredito getCredito,
                                 IGetCreditos getCreditos)
        {
            _crearCredito = crearCredito;
            _getCredito = getCredito;
            _getCreditos = getCreditos;
        }

        [HttpPost]
        public async Task<IResult> Crear(CrearCreditoRequest req)
        {
            var result = await _crearCredito.Crear(req);

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.BadRequest(error));
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(string id)
        {
            var result = await _getCredito.Get(id);

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.NotFound(result.Value));
        }

        [HttpGet]
        public async Task<IResult> GetCreditos([FromQuery]FiltroCredito filtro)
        {
            var result = await _getCreditos.GetCreditos(filtro);

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.NotFound(result.Value));
        }
    }
}
