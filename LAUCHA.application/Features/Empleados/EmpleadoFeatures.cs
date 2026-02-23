using LAUCHA.application.Features.Empleados.CrearEmpleado;
using LAUCHA.application.Features.Empleados.CrearEmpleadoAsistencias;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
using LAUCHA.application.Features.Empleados.GetEmpleados;

namespace LAUCHA.application.Features.Empleados
{
    internal static class EmpleadoFeatures
    {
        public static IServiceCollection AddEmpleadoFeatures(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearEmpleadoRequest>, CrearEmpleadoValidator>();
            services.AddScoped<IGetEmpleados, GetEmpleadosHandler>();
            services.AddScoped<ICrearEmpleado, CrearEmpleadoHandler>();
            services.AddScoped<IFabricaEmpleado, FabricaEmpleado>();
            services.AddScoped<IGetEmpleadoAsistencias, GetEmpleadoAsistenciasHandler>();
            services.AddScoped<ICrearAsistencia, CrearEmpleadoAsistenciaHandler>();

            return services;
        }
    }
}
