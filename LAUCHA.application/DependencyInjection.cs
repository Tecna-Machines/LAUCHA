using FluentValidation;
using LAUCHA.application.Features.Acuerdos.CrearAcuerdo;
using LAUCHA.application.Features.Acuerdos.GetAcuerdoById;
using LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado;
using LAUCHA.application.Features.Empleados.CrearEmpleado;
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
            services.AddScoped<IGetAcuerdoById, GetAcuerdoById>();
            services.AddScoped<IGetAcuerdosEmpleado,GetAcuerdosEmpleadoHandler>();

            return services;
        }

        private static IServiceCollection AddEmpleadosFeature(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearEmpleadoRequest>, CrearEmpleadoValidator>();
            services.AddScoped<IGetEmpleados, GetEmpleadosHandler>();
            services.AddScoped<ICrearEmpleado, CrearEmpleadoHandler>();
            services.AddScoped<IFabricaEmpleado, FabricaEmpleado>();

            return services;
        }
    }
}
