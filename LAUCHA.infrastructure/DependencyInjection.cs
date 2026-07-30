using LAUCHA.application.Features.Liquidaciones.GetRecibo;
using LAUCHA.application.Features.Liquidaciones.GetRecibos;
using LAUCHA.domain.Services.CalendarioLaboral;
using LAUCHA.infrastructure.persistence;
using LAUCHA.infrastructure.repositories;
using LAUCHA.infrastructure.Repositories;
using LAUCHA.infrastructure.Services.CalendarioLaboral;
using LAUCHA.infrastructure.Services.Recibos.Render;
using Microsoft.Extensions.DependencyInjection;

namespace LAUCHA.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<LiquidacionesDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    mySqlOptions =>
                    {
                        mySqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null
                        );
                    }
                )
            );

            //pdf
            services.AddScoped<IReciboRenderer, PdfReciboRenderer>();
            services.AddScoped<IReciboMultipleRenderer, PdfReciboMultipleRenderer>();

            services.AddScoped<IAcuerdoRepository, AcuerdoRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<ICatalogoRetencionRepository, CatalogoRetencionesRepository>();
            services.AddScoped<ICreditoRepository, CreditoRepository>();

            services.AddScoped<ILiquidacionRepository, LiquidacionRepository>();

            services.AddScoped<ICalendarioLaboral,CalendarioLaboralImp>();

            return services;
        }
    }
}
