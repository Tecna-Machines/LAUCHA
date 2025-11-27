using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Liquidaciones.CrearLiquidacion;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetLiquidaciones;
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
        private readonly IGetLiquidacionById _getLiquidacion;
        private readonly IGetLiquidaciones _getLiquidaciones;

        public LiquidacionController(ICrearLiquidacion crearLiquidacion,
                                     ILiquidar procesarLiquidacion,
                                     IGetLiquidacionById getLiquidacion,
                                     IGetLiquidaciones getLiquidaciones)
        {
            _crearLiquidacion = crearLiquidacion;
            _procesarLiquidacion = procesarLiquidacion;
            _getLiquidacion = getLiquidacion;
            _getLiquidaciones = getLiquidaciones;
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

        [HttpGet("{id}")]
        public async Task<IResult> GetById(string id)
        {
            var result = await _getLiquidacion.Get(id);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.Conflict(error)
            );
        }

        [HttpGet()]
        public async Task<IResult> GetByQuincena(int? quincena,int? anio,int? mes)
        {
            var hoy = DateTime.Now;
            var result = await _getLiquidaciones.Get(new GetLiquidacionesRequest(quincena ?? 1,mes ?? hoy.Month,anio ?? hoy.Year));

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }

    }
}
