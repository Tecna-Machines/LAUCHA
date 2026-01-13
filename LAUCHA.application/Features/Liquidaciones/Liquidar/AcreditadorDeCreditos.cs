using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class AcreditadorDeCreditos
    {
        private ICreditoRepository _creditos;

        public AcreditadorDeCreditos(ICreditoRepository creditos)
        {
            _creditos = creditos;
        }

        public async Task<IEnumerable<ItemLiquidacion>> GenerarItemsDeAcreditacion(Liquidacion liq)
        {
            await DeshacerCreditosParaRecalcular(liq.Codigo);

            var items = new List<ItemLiquidacion>();
            var creditos = await BuscarCreditosPendientesDeAcreditacion(liq.DniEmpleado);

            foreach(var credito in creditos)
            {
                var itemAcreditacion = credito.Acreditar(liq);
                items.Add(itemAcreditacion);

            }

            return items;
        }

        private Task<IReadOnlyCollection<Credito>> BuscarCreditosAcreditadosParaDeshacer(string codiLiquidacion)
         => _creditos.Buscar(new CreditoQuery { CodigoLiquidacion = codiLiquidacion });

        private Task<IReadOnlyCollection<Credito>> BuscarCreditosPendientesDeAcreditacion(string dniEmpleado)
         => _creditos.Buscar(new CreditoQuery { DniEmpleado = dniEmpleado, Estado = EstadoCredito.SOLICITADO });


        private async Task DeshacerCreditosParaRecalcular(string codigoLiquidacion)
        {
            var creditos = await BuscarCreditosAcreditadosParaDeshacer(codigoLiquidacion);

            foreach (var credito in creditos)
            {
                credito.Desacreditar();
            }
        }


    }
}
