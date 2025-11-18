using LAUCHA.application.Common.ResultResponse;

namespace LAUCHA.application.Features.Liquidaciones.AnularItem
{
    internal class AnularItemHandler : IAnularItem
    {
        private readonly ILiquidacionRepository _liquidaciones;

        public AnularItemHandler(ILiquidacionRepository liquidaciones)
        {
            _liquidaciones = liquidaciones;
        }

        public async Task<Result<AnularItemResponse>> Anular(string codigoLiquidacion, int NroItem)
        {
            var liquidacion = await _liquidaciones.GetById(codigoLiquidacion);

            if (liquidacion is null)
                return Result.Failure<AnularItemResponse>(LiquidacionErrors.NoExistente);

            if (liquidacion.EstaSellada())
                return Result.Failure<AnularItemResponse>(LiquidacionErrors.Sellada);

            var item = GetItemFromLiquidacion(liquidacion, NroItem);

            if (item is null)
                return Result.Failure<AnularItemResponse>(LiquidacionErrors.NoItem);

            item.Anular();

            await _liquidaciones.Update(liquidacion);

            string estado = "";

            if (item.Estado == EstadoItemLiquidacion.ANULADO)
                estado = "ANULADO";

            return Result.Success(new AnularItemResponse(item.CodigoLiquidacion, item.NroItem, estado));

        }

        private ItemLiquidacion? GetItemFromLiquidacion(Liquidacion liquidacion, int nroItem)
        {
            return liquidacion.GetItems().First(it => it.NroItem == nroItem);
        }
    }
}
