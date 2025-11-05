using FluentValidation;
using LAUCHA.application.Features.Acuerdos.CrearAcuerdo;
using LAUCHA.application.Features.Empleados.GetEmpleados;
using Microsoft.Extensions.DependencyInjection;


namespace LAUCHA.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            AddAcuerdosFeature(services);
            AddEmpleadosFeature(services);
            return services;
        }

        private static IServiceCollection AddAcuerdosFeature(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearAcuerdoRequest>, CrearAcuerdoValidator>();
            services.AddScoped<ICrearAcuerdo, CrearAcuerdoHandler>();
            return services;
        }

        private static IServiceCollection AddEmpleadosFeature(this IServiceCollection services)
        {
            services.AddScoped<IGetEmpleados, GetEmpleadosHandler>();
            return services;
        }
    }
}
