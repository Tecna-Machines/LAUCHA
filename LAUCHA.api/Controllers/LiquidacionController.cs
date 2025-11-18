using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Liquidaciones.CrearLiquidacion;
using LAUCHA.application.Features.Liquidaciones.Liquidar;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LiquidacionController : ControllerBase
    {
        private readonly ICrearLiquidacion _crearLiquidacion;
        private readonly ILiquidar _procesarLiquidacion;

        public LiquidacionController(ICrearLiquidacion crearLiquidacion, ILiquidar procesarLiquidacion)
        {
            _crearLiquidacion = crearLiquidacion;
            _procesarLiquidacion = procesarLiquidacion;
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

        [HttpPut("{id}/liquidar")]
        public async Task<IResult> Liquidar(string id)
        {
 
            var result = await _procesarLiquidacion.Liquidar(new LiquidarRequest(id));

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.Conflict(error)
            );
        }

    }
}
