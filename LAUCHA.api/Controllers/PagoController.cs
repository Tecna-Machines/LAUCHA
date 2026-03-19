using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Liquidaciones.PagarLiquidacion;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagarLiquidacion _pagarLiquidacion;

        public PagoController(IPagarLiquidacion pagarLiquidacion)
        {
            _pagarLiquidacion = pagarLiquidacion;
        }

        [HttpPost]
        public async Task<IResult> PagarLiquidacion(CrearPagoRequest req)
        {
            var result = await _pagarLiquidacion.Pagar(req);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.BadRequest(error));
        }

    }
}
