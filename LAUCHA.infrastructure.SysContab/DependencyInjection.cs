using LAUCHA.application.Integrations.SysContab;
using LAUCHA.infrastructure.SysContab.Models;
using LAUCHA.infrastructure.SysContab.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LAUCHA.infrastructure.SysContab
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSysContab(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config["ConnectionStrings:Contabilidad"] ?? throw new NullReferenceException("falta.string");

            services.AddDbContext<TecnaDb3Context>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<ICuentasContablesService, CuentasContablesService>();
            services.AddScoped<IContabilidadService, ContabilidadService>();

            services.AddScoped<PagosContabService>();
            services.AddScoped<MovimientosContabService>();
            return services;
        }
    }
}
