using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.Cuotas.PosponerDebito
{
    internal class PosponerCuotaHandler : IPosponerCuota
    {
        private readonly ICreditoRepository _creditos;

        public PosponerCuotaHandler(ICreditoRepository creditos)
        {
            _creditos = creditos;
        }

        public async Task<Result<PosponerCuotaResponse>> Posponer(PosponerCuotaRequest req)
        {
            var credito = await _creditos.GetById(req.CodigoCredito);

            if (credito is null)
                return Result.Failure<PosponerCuotaResponse>(Error.Null);

            PosponerCuota(credito, req.NroCuota);

            try
            {
                await _creditos.Update(credito);

            }catch(Exception ex)
            {
                return Result.Failure<PosponerCuotaResponse>(new Error(ex.Message));
            }

            return Result.Success(new PosponerCuotaResponse());
        }

        private void PosponerCuota(Credito credito,int NroCuota)
        {
            var cuotasSinPagar = credito.GetCuotasSinPagar();

            cuotasSinPagar = cuotasSinPagar.Where(c => c.Nro >= NroCuota).
                                            ToList();
     
           if(credito.ModoPago == ModoPagoCredito.AMBAS_QUINCENAS)
            {
                foreach (var cuota in cuotasSinPagar)
                {
                    cuota.PosponerUnaQuincena();
                }

                return;
            }


            foreach (var cuota in cuotasSinPagar)
            {
                cuota.PosponerUnMes();
            }
        }
    }
}
