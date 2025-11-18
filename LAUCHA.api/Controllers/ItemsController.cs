using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Liquidaciones.AnularItem;
using LAUCHA.application.Features.Liquidaciones.CrearItem;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/liquidacion/{codigo}/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ICrearItem _crearItems;
        private readonly IAnularItem _anularItem;

        public ItemsController(ICrearItem crearItems, IAnularItem anularItem)
        {
            _crearItems = crearItems;
            _anularItem = anularItem;
        }

        [HttpPost]
        public async Task<IResult> CrearItem(string codigo, [FromBody] CrearItemRequest req)
        {
            var result = await _crearItems.Crear(codigo, req);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.BadRequest(error));
        }

        [HttpPatch("{nroItem:int}")]
        public async Task<IResult> ActualizarEstadoItem(
        string codigo,
        int nroItem)
        {
            var result = await _anularItem.Anular(codigo, nroItem);

            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: (error) => Results.BadRequest(error));
        }
    }
}
