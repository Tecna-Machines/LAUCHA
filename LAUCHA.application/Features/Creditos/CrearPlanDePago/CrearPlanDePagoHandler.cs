using LAUCHA.application.Features.Creditos.CrearCredito;
using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.CrearPlanDePago
{
    internal class CrearPlanDePagoHandler : ICrearPlanDePago
    {
        private readonly ICreditoRepository _creditos;

        public CrearPlanDePagoHandler(ICreditoRepository creditos)
        {
            _creditos = creditos;
        }

        public async Task<Result<CrearPlanDePagoResponse>> Crear(string codigoCredito, CrearPlanDePagoRequest req)
        {
            var credito = await _creditos.GetById(codigoCredito);

            if (credito is null)
                return Result.Failure<CrearPlanDePagoResponse>(Error.Null);

            var cuotasPlanDePago = GenerarCuotasPlanDePago(credito, req.CantCuotas, new CreditoQuincenaRequest(req.QuincenaInicio, req.MesInicio, req.AnioInicio));

            credito.ReemplazarCuotasPendientes(cuotasPlanDePago);

            try
            {
                await _creditos.Update(credito);
            }
            catch (Exception e)
            {
                return Result.Failure<CrearPlanDePagoResponse>(new Error(e.Message));
            }

            return Result.Success(new CrearPlanDePagoResponse(credito.Codigo));

        }

        private IReadOnlyCollection<CuotaCredito> GenerarCuotasPlanDePago(Credito credito, int cantidadCuotas, CreditoQuincenaRequest inicioPago)
        {
            var cuotasPlanDePago = new List<CuotaCredito>();
            decimal montoPorPagar = credito.MontoDevolver - credito.GetMondoPagado();
            decimal montoCuota = montoPorPagar / cantidadCuotas;

            CreditoQuincenaRequest actual = inicioPago;

            for (int nro = 1; nro <= cantidadCuotas; nro++)
            {
                int ultimoNroPagado = credito.Cuotas
                                    .Where(c => c.Estado == CuotaCredito.EstadoCuota.PAGADA)
                                    .Select(c => c.Nro)
                                    .DefaultIfEmpty(0)
                                    .Max();

                int nroConPlanDePago = ultimoNroPagado + nro;
                var cuota = CuotaCredito.Crear(nroConPlanDePago, montoCuota);

                cuota.AsignarCredito(credito);
                cuota.SetDescripcion($"[PP]: {credito.Descripcion} , ({nro}/{cantidadCuotas})");
                cuota.SetQuincenaDebitar(actual.Quincena, actual.Mes, actual.Anio);
                cuotasPlanDePago.Add(cuota);

                actual = SiguienteQuincena(credito.ModoPago, actual);
            }

            return cuotasPlanDePago;
        }

        //TODO: esto es logica repetida de otra clase , se debe refactorizar por ahor la dejo asi
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
