using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Liquidaciones.CrearLiquidacion;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LiquidacionController : ControllerBase
    {
        private readonly ICrearLiquidacion _crearLiquidacion;

        public LiquidacionController(ICrearLiquidacion crearLiquidacion)
        {
            _crearLiquidacion = crearLiquidacion;
        }

        [HttpPost]
        public async Task<IResult> CrearLiquidacion(CrearLiquidacionRequest req)
        {
            var result = await _crearLiquidacion.Crear(req);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.Conflict(error)
                );
        }
    }
}
