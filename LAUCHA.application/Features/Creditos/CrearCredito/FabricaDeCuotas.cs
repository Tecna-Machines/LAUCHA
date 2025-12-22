using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.CrearCredito
{
    internal class FabricaDeCuotas : IFabricaDeCuotas
    {

        public IReadOnlyCollection<CuotaCredito> Fabricar(Credito credito, CreditoQuincenaRequest quincenaInicio)
        {
            if (credito.CantidadCuotas <= 0)
                throw new ArgumentOutOfRangeException(nameof(credito.CantidadCuotas));

            var cuotas = new List<CuotaCredito>(credito.CantidadCuotas);

            var actual = quincenaInicio;

            var montoBase = Math.Round(
                credito.MontoDevolver / credito.CantidadCuotas,
                2,
                MidpointRounding.AwayFromZero
            );

            for (int nro = 1; nro <= credito.CantidadCuotas; nro++)
            {
                var monto = (nro == credito.CantidadCuotas)
                    ? credito.MontoDevolver - montoBase * (credito.CantidadCuotas - 1)
                    : montoBase;

                var cuota = CuotaCredito.Crear(nro, monto);
                cuota.SetDescripcion($"{credito.Descripcion} cuota: {nro}/{credito.CantidadCuotas}");
                cuota.SetQuincenaDebitar(actual.Quincena, actual.Mes, actual.Anio);

                cuotas.Add(cuota);

                actual = SiguienteQuincena(credito.ModoPago, actual);
            }

            return cuotas;
        }



        private static CreditoQuincenaRequest SiguienteQuincena(ModoPagoCredito modo, CreditoQuincenaRequest actual)
        {
            return modo switch
            {
                ModoPagoCredito.AMBAS_QUINCENAS =>
                    AvanzarUnaQuincena(actual),

                ModoPagoCredito.PRIMERA_QUINCENA =>
                    AvanzarMesQuincenaFija(actual, 1),

                ModoPagoCredito.SEGUNDA_QUINCENA =>
                    AvanzarMesQuincenaFija(actual, 2),

                _ => throw new InvalidOperationException($"ModoPago no soportado: {modo}")
            };
        }

        private static CreditoQuincenaRequest AvanzarUnaQuincena(CreditoQuincenaRequest a)
        {
            if (a.Quincena == 1)
                return new CreditoQuincenaRequest(2, a.Mes, a.Anio);

            var mes = a.Mes + 1;
            var anio = a.Anio;

            if (mes > 12)
            {
                mes = 1;
                anio++;
            }

            return new CreditoQuincenaRequest(1, mes, anio);
        }

        private static CreditoQuincenaRequest AvanzarMesQuincenaFija(
            CreditoQuincenaRequest a,
            int quincenaFija)
        {
            var mes = a.Mes + 1;
            var anio = a.Anio;

            if (mes > 12)
            {
                mes = 1;
                anio++;
            }

            return new CreditoQuincenaRequest(quincenaFija, mes, anio);
        }
    }
}
