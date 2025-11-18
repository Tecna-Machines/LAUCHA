using FluentValidation;
using LAUCHA.application.Features.Acuerdos.CrearAcuerdo;
using LAUCHA.application.Features.Acuerdos.GetAcuerdoById;
using LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado;
using LAUCHA.application.Features.CatalogoRetenciones.GetCatalogo;
using LAUCHA.application.Features.Empleados.CrearEmpleado;
using LAUCHA.application.Features.Empleados.GetEmpleados;
using LAUCHA.application.Features.Liquidaciones.AnularItem;
using LAUCHA.application.Features.Liquidaciones.CrearItem;
using LAUCHA.application.Features.Liquidaciones.CrearLiquidacion;
using LAUCHA.application.Features.Liquidaciones.Liquidar;
using Microsoft.Extensions.DependencyInjection;


namespace LAUCHA.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            AddAcuerdosFeature(services);
            AddEmpleadosFeature(services);
            AddLiquidacionFeatures(services);
            AddItemsFeatures(services);
            AddCatalogoRetencionesFeatures(services);

            return services;
        }

        private static IServiceCollection AddAcuerdosFeature(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearAcuerdoRequest>, CrearAcuerdoValidator>();
            services.AddScoped<ICrearAcuerdo, CrearAcuerdoHandler>();
            services.AddScoped<IGetAcuerdoById, GetAcuerdoById>();
            services.AddScoped<IGetAcuerdosEmpleado, GetAcuerdosEmpleadoHandler>();

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

        private static IServiceCollection AddLiquidacionFeatures(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearLiquidacionRequest>, CrearLiquidacionValidator>();
            services.AddScoped<ICrearLiquidacion, CrearLiquidacionHandler>();

            //liquidar
            services.AddScoped<ICalculadoraDeSueldos, CalculadoraSueldo>();
            services.AddScoped<ICalculadoraRetenciones, CalculadoraRetenciones>();
            services.AddScoped<ILiquidacionDeHaberes, LiquidacionDeHaberes>();

            services.AddScoped<ILiquidar, LiquidarHandler>();

            return services;
        }

        private static IServiceCollection AddItemsFeatures(this IServiceCollection services)
        {
            services.AddScoped<IFabricaItem, FabricaItem>();
            services.AddScoped<ICrearItem, CrearItemHandler>();

            services.AddScoped<IAnularItem, AnularItemHandler>();

            return services;
        }

        private static IServiceCollection AddCatalogoRetencionesFeatures(this IServiceCollection services)
        {
            services.AddScoped<IGetCatalogo, GetCatalogoHandler>();
            return services;
        }
    }
}
