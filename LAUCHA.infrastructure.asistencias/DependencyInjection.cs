using LAUCHA.domain.Entities.Asistencias;
using LAUCHA.infrastructure.asistencias.Persistence;
using LAUCHA.infrastructure.asistencias.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LAUCHA.infrastructure.asistencias
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAsistenciasPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MarcasMySqlContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IAsistenciasSource, MarcasRepository>();

            return services;
        }
    }
}
