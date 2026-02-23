using LAUCHA.application.Features.CatalogoRetenciones.GetCatalogo;

namespace LAUCHA.application.Features.CatalogoRetenciones
{
    internal static class CatalogoRetencionesFeatures
    {
        public static IServiceCollection AddCatalogoFeatures(this IServiceCollection services)
        {
            services.AddScoped<IGetCatalogo, GetCatalogoHandler>();

            return services;
        }
    }
}
