using LAUCHA.infrastructure.asistencias.Models;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.asistencias.Persistence
{
    internal class MarcasMySqlContext : DbContext
    {
        public DbSet<MarcasMySQL> Marcas { get; set; }

        public MarcasMySqlContext(DbContextOptions<MarcasMySqlContext> options) : base(options) { }
    }
}
