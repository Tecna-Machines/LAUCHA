using FluentValidation;
using LAUCHA.application.Features.Acuerdos.CrearAcuerdo;
using Microsoft.Extensions.DependencyInjection;


namespace LAUCHA.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearAcuerdoRequest>, CrearAcuerdoValidator>();
            services.AddScoped<ICrearAcuerdo, CrearAcuerdoHandler>();
            return services;
        }
    }
}
