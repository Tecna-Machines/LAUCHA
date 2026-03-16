using LAUCHA.infrastructure.SysContab.Models;
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
            return services;
        }
    }
}
