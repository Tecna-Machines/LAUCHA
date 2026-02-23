using LAUCHA.application.Features.Creditos.CrearCredito;
using LAUCHA.application.Features.Creditos.CrearPlanDePago;
using LAUCHA.application.Features.Creditos.Cuotas.PosponerDebito;
using LAUCHA.application.Features.Creditos.GetCredito;
using LAUCHA.application.Features.Creditos.GetCreditos;

namespace LAUCHA.application.Features.Creditos
{
    internal static class CreditosFeatures
    {
        public static IServiceCollection AddCreditosFeatures(this IServiceCollection services)
        {
            services.AddScoped<IFabricaDeCuotas, FabricaDeCuotas>();
            services.AddScoped<ICrearCredito, CrearCreditoHandler>();

            services.AddScoped<IGetCredito, GetCreditoByIdHandler>();
            services.AddScoped<IGetCreditos, GetCreditosHandler>();

            services.AddScoped<IPosponerCuota, PosponerCuotaHandler>();

            services.AddScoped<ICrearPlanDePago, CrearPlanDePagoHandler>();

            return services;
        }
    }
}
