using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.CrearCredito
{
    public interface IFabricaDeCuotas
    {
        public IReadOnlyCollection<CuotaCredito> Fabricar(Credito credito, CreditoQuincenaRequest quincenaInicio);
    }
}
