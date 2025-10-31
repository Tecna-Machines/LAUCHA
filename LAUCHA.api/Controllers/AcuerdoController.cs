using LAUCHA.application.Common.Extensions;
using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.Features.Acuerdos.CrearAcuerdo;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AcuerdoController : ControllerBase
    {
        private readonly ICrearAcuerdo _crearAcuerdo;

        public AcuerdoController(ICrearAcuerdo crearAcuerdo)
        {
            _crearAcuerdo = crearAcuerdo;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ConceptoDTO), 201)]
        public async Task<IResult> CrearAcuerdo(CrearAcuerdoRequest req)
        {
            var result = await _crearAcuerdo.Crear(req);

            return result.Math(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }
    }
}
