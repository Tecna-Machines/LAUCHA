using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    internal class CobradorDeCuotas
    {
        private readonly ICreditoRepository _creditos;

        public CobradorDeCuotas(ICreditoRepository creditos)
        {
            _creditos = creditos;
        }

        public async Task<IEnumerable<ItemLiquidacion>> GenerarItemsDeCuota(Liquidacion liq)
        {
            var items = new List<ItemLiquidacion>();
            var creditosPorPagar = await BuscarCreditosConCuotasPendientes(liq.DniEmpleado);

            foreach (var credito in creditosPorPagar)
            {
                var cuotaPagar = credito.GetCuotasSinPagar()
                                .FirstOrDefault(c => c.QuincenaDebitar == liq.Quincena
                                                            && c.MesDebitar == liq.Mes
                                                            && c.AnioDebitar == liq.Anio);

                if (cuotaPagar is null) continue;


                cuotaPagar.AsociarConLiquidacion(liq);
                credito.PagarCuota(cuotaPagar.Nro);

                var it = ItemLiquidacion.CrearDescuentoEnNegro($"{cuotaPagar.Descripcion}", cuotaPagar.Monto);
                items.Add(it);
            }

            return items;
        }

        private Task<IReadOnlyCollection<Credito>> BuscarCreditosConCuotasPendientes(string dniEmpleado)
         => _creditos.Buscar(new CreditoQuery { DniEmpleado = dniEmpleado, Estado = EstadoCredito.PENDIENTE });
    }
}
