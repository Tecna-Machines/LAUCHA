using LAUCHA.domain.interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.Services.Marcas.Persistence
{
    public class MarcasDbContext : DbContext
    {
        public DbSet<Marca> Marcas { get; set; }

        public MarcasDbContext(DbContextOptions<MarcasDbContext> options) : base(options) { }
    }
}
