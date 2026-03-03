using LAUCHA.application.Features.Feriados.CrearFeriado;

namespace LAUCHA.application.Features.Feriados
{
    internal static class FeriadoFeatures
    {
        public static IServiceCollection AddFeriadoFeatures(this IServiceCollection services)
        {
            services.AddScoped<ICrearFeriado, CrearFeriadoHandler>();

            return services;
        }
    }
}
