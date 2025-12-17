using LAUCHA.application.Features.Liquidaciones.GetRecibo;
using LAUCHA.application.Features.Liquidaciones.GetRecibos;
using LAUCHA.infrastructure.repositories;
using LAUCHA.infrastructure.Repositories;
using LAUCHA.infrastructure.Services.Recibos;
using Microsoft.Extensions.DependencyInjection;

namespace LAUCHA.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAcuerdoRepository, AcuerdoRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<ICatalogoRetencionRepository, CatalogoRetencionesRepository>();

            services.AddScoped<ILiquidacionRepository, LiquidacionRepository>();

            //pdf
            services.AddScoped<IReciboRenderer, PdfReciboRenderer>();
            services.AddScoped<IReciboMultipleRenderer, PdfReciboMultipleRenderer>();
            return services;
        }
    }
}
