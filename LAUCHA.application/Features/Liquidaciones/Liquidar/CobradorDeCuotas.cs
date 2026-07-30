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
            var creditosPorPagar = await BuscarCreditos(liq.DniEmpleado);

            foreach (var credito in creditosPorPagar)
            {
                DeshacerCuotasPagadaEnLiquidacion(credito, liq);


                var cuotaPagar = credito.GetCuotasSinPagar()
                                .FirstOrDefault(c => c.QuincenaDebitar == liq.Quincena
                                                            && c.MesDebitar == liq.Mes
                                                            && c.AnioDebitar == liq.Anio);

                if (cuotaPagar is null) continue;


                cuotaPagar.AsociarConLiquidacion(liq);
                credito.PagarCuota(cuotaPagar.Nro);

                var it = ItemLiquidacion.CrearDescuentoInterno($"{cuotaPagar.Descripcion}", cuotaPagar.Monto);
                items.Add(it);

                await _creditos.Update(credito);
            }

            return items;
        }

        private Task<IReadOnlyCollection<Credito>> BuscarCreditos(string dniEmpleado)
         => _creditos.Buscar(new CreditoQuery { DniEmpleado = dniEmpleado });

        //TODO: esto es muy rebuscado pero existe porque al recalcular , podria ser que hayams pateado cuotas y no queremos
        //que parezcan en esta liquidacion
        private void DeshacerCuotasPagadaEnLiquidacion(Credito credito, Liquidacion liq)
        {
            var cuotas = credito.GetCuotas().Where(c => c.QuincenaDebitar == liq.Quincena
                                                            && c.MesDebitar == liq.Mes
                                                            && c.AnioDebitar == liq.Anio);

            foreach (var cuota in cuotas)
            {
                cuota.AnularPago();
            }

        }


    }
}
