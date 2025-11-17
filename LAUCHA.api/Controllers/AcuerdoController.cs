using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Acuerdos.CrearAcuerdo;
using LAUCHA.application.Features.Acuerdos.GetAcuerdoById;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AcuerdoController : ControllerBase
    {
        private readonly ICrearAcuerdo _crearAcuerdo;
        private readonly IGetAcuerdoById _getAcuerdo;

        public AcuerdoController(ICrearAcuerdo crearAcuerdo, IGetAcuerdoById getAcuerdo)
        {
            _crearAcuerdo = crearAcuerdo;
            _getAcuerdo = getAcuerdo;
        }

        [HttpPost]
        public async Task<IResult> CrearAcuerdo(CrearAcuerdoRequest req)
        {
            var result = await _crearAcuerdo.Crear(req);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetAcuerdo(string id)
        {
            var result = await _getAcuerdo.GetAcuerdo(new GetAcuerdoByIdResquest(id));

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }

    }
}
