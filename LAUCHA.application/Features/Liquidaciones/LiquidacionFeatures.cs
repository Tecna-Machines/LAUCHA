using LAUCHA.application.Features.Liquidaciones.AnularItem;
using LAUCHA.application.Features.Liquidaciones.CrearItem;
using LAUCHA.application.Features.Liquidaciones.CrearLiquidacion;
using LAUCHA.application.Features.Liquidaciones.GetLiquidacionById;
using LAUCHA.application.Features.Liquidaciones.GetLiquidaciones;
using LAUCHA.application.Features.Liquidaciones.GetRecibo;
using LAUCHA.application.Features.Liquidaciones.GetRecibos;
using LAUCHA.application.Features.Liquidaciones.Liquidar;
using LAUCHA.application.Features.Liquidaciones.PagarLiquidacion;
using LAUCHA.application.Features.Liquidaciones.SellarLiquidacion;


namespace LAUCHA.application.Features.Liquidaciones
{
    internal class LiquidacionFeatures
    {
        public static IServiceCollection AddLiquidacionFeatures(IServiceCollection services)
        {
            services.AddScoped<IValidator<CrearLiquidacionRequest>, CrearLiquidacionValidator>();
            services.AddScoped<ICrearLiquidacion, CrearLiquidacionHandler>();
            services.AddScoped<IGetLiquidaciones, GetLiquidacionesHandler>();

            //liquidar
            services.AddScoped<AcreditadorDeCreditos>();
            services.AddScoped<CobradorDeCuotas>();
            services.AddScoped<CalculadoraHorasEspeciales>();

            services.AddScoped<ILiquidador, Liquidador>();

            services.AddScoped<ILiquidar, LiquidarHandler>();
            services.AddScoped<IGetLiquidacionById, GetLiquidacionByIdHandler>();

            services.AddScoped<ISellarLiquidacion, SellarLiquidacionHandler>();

            services.AddScoped<IGetRecibo, GetReciboHandler>();

            services.AddScoped<IGetRecibo, GetReciboHandler>();
            services.AddScoped<IGetRecibos, GetRecibosHandler>();


            //items liquidacion
            services.AddScoped<IFabricaItem, FabricaItem>();
            services.AddScoped<ICrearItem, CrearItemHandler>();
            services.AddScoped<IAnularItem, AnularItemHandler>();

            //pagos
            services.AddScoped<IPagarLiquidacion, PagarLiquidacionHandler>();


            return services;
        }
    }
}
