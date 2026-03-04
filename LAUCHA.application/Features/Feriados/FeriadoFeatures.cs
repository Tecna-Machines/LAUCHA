using LAUCHA.application.Features.Feriados.CrearFeriado;
using LAUCHA.application.Features.Feriados.GetFeriadoMes;

namespace LAUCHA.application.Features.Feriados
{
    internal static class FeriadoFeatures
    {
        public static IServiceCollection AddFeriadoFeatures(this IServiceCollection services)
        {
            services.AddScoped<ICrearFeriado, CrearFeriadoHandler>();
            services.AddScoped<IGetFeriadosMes, GetFeriadoMesHandler>();

            return services;
        }
    }
}
