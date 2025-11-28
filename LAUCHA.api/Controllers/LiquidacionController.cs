using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Liquidaciones.CrearLiquidacion;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetLiquidaciones;
using LAUCHA.application.Features.Liquidaciones.Liquidar;
using LAUCHA.application.Features.Liquidaciones.SellarLiquidacion;
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
        private readonly ISellarLiquidacion _sellarLiquidacion;

        public LiquidacionController(ICrearLiquidacion crearLiquidacion,
                                     ILiquidar procesarLiquidacion,
                                     IGetLiquidacionById getLiquidacion,
                                     IGetLiquidaciones getLiquidaciones,
                                     ISellarLiquidacion sellarLiquidacion)
        {
            _crearLiquidacion = crearLiquidacion;
            _procesarLiquidacion = procesarLiquidacion;
            _getLiquidacion = getLiquidacion;
            _getLiquidaciones = getLiquidaciones;
            _sellarLiquidacion = sellarLiquidacion;
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
        public async Task<IResult> GetByQuincena(int? quincena, int? anio, int? mes)
        {
            var hoy = DateTime.Now;
            var result = await _getLiquidaciones.Get(new GetLiquidacionesRequest(quincena ?? 1, mes ?? hoy.Month, anio ?? hoy.Year));

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }

        [HttpPut("{id}/sellar")]
        public async Task<IResult> Sellar(string id)
        {
            var result = await _sellarLiquidacion.Sellar(id);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.Conflict(error));
        }

    }
}
