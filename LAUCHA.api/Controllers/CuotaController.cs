using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Creditos.Cuotas.PosponerDebito;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/credito/{codigo}/cuota")]
    [ApiController]

    public class CuotaController : ControllerBase
    {
        private readonly IPosponerCuota _posponerCuota;

        public CuotaController(IPosponerCuota posponerCuota)
        {
            _posponerCuota = posponerCuota;
        }

        [HttpPost("{nro:int}/posponer")]
        public async Task<IResult> PosponerCuota(string codigo, int nro)
        {
            var result = await _posponerCuota.Posponer(new PosponerCuotaRequest(codigo, nro));

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.Problem(error.Descripcion));
        }
    }
}
