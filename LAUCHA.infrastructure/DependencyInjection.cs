using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LAUCHA.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAcuerdoRepository, AcuerdoRepository>();
            services.AddScoped<IEmpleadoRepository,EmpleadoRepository>();
            return services;
        }
    }
}
