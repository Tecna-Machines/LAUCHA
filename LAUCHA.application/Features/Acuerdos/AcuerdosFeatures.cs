using LAUCHA.application.Features.Acuerdos.CrearAcuerdo;
using LAUCHA.application.Features.Acuerdos.GetAcuerdoById;
using LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado;

namespace LAUCHA.application.Features.Acuerdos
{
    internal static class AcuerdosFeatures
    {
        public static IServiceCollection AddAcuerdosFeatures(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearAcuerdoRequest>, CrearAcuerdoValidator>();
            services.AddScoped<ICrearAcuerdo, CrearAcuerdoHandler>();
            services.AddScoped<IGetAcuerdoById, GetAcuerdoByIdHandler>();
            services.AddScoped<IGetAcuerdosEmpleado, GetAcuerdosEmpleadoHandler>();


            return services;
        }
    }
}
