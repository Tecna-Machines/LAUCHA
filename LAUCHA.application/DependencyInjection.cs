using LAUCHA.application.Features.Acuerdos;
using LAUCHA.application.Features.CatalogoRetenciones;
using LAUCHA.application.Features.Creditos;
using LAUCHA.application.Features.Empleados;
using LAUCHA.application.Features.Liquidaciones;
namespace LAUCHA.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AcuerdosFeatures.AddAcuerdosFeatures(services);
            EmpleadoFeatures.AddEmpleadoFeatures(services);
            LiquidacionFeatures.AddLiquidacionFeatures(services);
            CatalogoRetencionesFeatures.AddCatalogoFeatures(services);
            CreditosFeatures.AddCreditosFeatures(services);

            return services;
        }



    }
}
