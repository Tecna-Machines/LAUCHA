using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Integrations.SysContab;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentasContablesService _cuentasContables;

        public CuentasController(ICuentasContablesService cuentasContables)
        {
            _cuentasContables = cuentasContables;
        }

        [HttpGet("cuentas-contables")]
        public async Task<IResult> GetCuentas()
        {
            var result = await _cuentasContables
                                .GetCuentasContables();

            return result.Match(onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.Problem(error.Descripcion));
        }
    }
}
