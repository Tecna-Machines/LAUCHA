using LAUCHA.application.Common.ResultResponse;
using LAUCHA.application.Mappers;

namespace LAUCHA.application.Features.Liquidaciones.CrearItem
{
    internal class CrearItemHandler : ICrearItem
    {
        private readonly IFabricaItem _fabricaItems;
        private readonly ILiquidacionRepository _liquidaciones;

        public CrearItemHandler(ILiquidacionRepository liquidaciones, IFabricaItem fabricaItems)
        {
            _liquidaciones = liquidaciones;
            _fabricaItems = fabricaItems;
        }

        public async Task<Result<CrearItemResponse>> Crear(string codigoLiquidacion, CrearItemRequest req)
        {
            var liquidacion = await _liquidaciones.GetById(codigoLiquidacion);

            if (liquidacion is null)
                return Result.Failure<CrearItemResponse>(LiquidacionErrors.Existente);

            if (liquidacion.EstaSellada())
                return Result.Failure<CrearItemResponse>(LiquidacionErrors.Sellada);

            var item = _fabricaItems.Crear(req);

            liquidacion.AgregarItem(item);

            item.NroItem += 100;

            await _liquidaciones.Update(liquidacion);

            return Result.Success(MapToItemResponse(item));
        }

        private CrearItemResponse MapToItemResponse(ItemLiquidacion item) => new(
            CodigoLiquidacion: item.CodigoLiquidacion,
            NroItem: item.NroItem,
            Concepto: item.Concepto,
            Monto: item.Monto,
            EsEnBlanco: item.EsEnBlanco,
            Tipo: TipoItemLiquidacionMapper.ToInt(item.Tipo),
            Fecha: item.Fecha
            );
        
    }
}
