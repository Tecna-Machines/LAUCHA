using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.Entities.Liquidaciones;
using LAUCHA.domain.Entities.RetencionesCatalogo;
using LAUCHA.infrastructure.repositories;
using LAUCHA.infrastructure.Repositories;
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
            return services;
        }
    }
}
