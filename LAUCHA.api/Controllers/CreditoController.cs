using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Creditos.CrearCredito;
using LAUCHA.application.Features.Creditos.CrearPlanDePago;
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
        private readonly ICrearPlanDePago _planDePago;

        public CreditoController(ICrearCredito crearCredito,
                                 IGetCredito getCredito,
                                 IGetCreditos getCreditos,
                                 ICrearPlanDePago planDePago)
        {
            _crearCredito = crearCredito;
            _getCredito = getCredito;
            _getCreditos = getCreditos;
            _planDePago = planDePago;
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
        public async Task<IResult> GetCreditos([FromQuery] FiltroCredito filtro)
        {
            var result = await _getCreditos.GetCreditos(filtro);

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.NotFound(result.Value));
        }

        [HttpPost("{id}/plan-de-pago")]
        public async Task<IResult> GenerarPlanDePagos(string id,[FromBody]CrearPlanDePagoRequest req)
        {
            var result = await _planDePago.Crear(id,req);

            return result.Match(onSucces: () => Results.Ok(result.Value),
               onFailure: (error) => Results.NotFound(result.Value));
        }
    }
}
