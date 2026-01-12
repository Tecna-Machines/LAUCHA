using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class CalculadoraDescuentos
    {
        private ICreditoRepository _creditos;

        public CalculadoraDescuentos(ICreditoRepository creditos)
        {
            _creditos = creditos;
        }

        public async Task<IEnumerable<ItemLiquidacion>> GenerarItemsDescuentos(Liquidacion liq)
        {
            var items = new List<ItemLiquidacion>();

            var creditosSinPagar = await GetCreditosSinPagar(liq.DniEmpleado);

            foreach (var credito in creditosSinPagar)
            {
                items.Add(GenerarItemDeCuota(credito));
            }

            return items;
        }


        private  async Task<IReadOnlyCollection<Credito>> GetCreditosSinPagar(string dniEmpleado)
        {
            var filtroBusqueda = new CreditoQuery{ DniEmpleado = dniEmpleado, 
                                                   Estado = EstadoCredito.INCOMPLETO };

            return await _creditos.Buscar(filtroBusqueda);
        }

        private ItemLiquidacion GenerarItemDeCuota(Credito credito)
        {
            credito.GetCuotasSinPagar();
            throw new NotImplementedException();
        }

    
    }
}
