using LAUCHA.infrastructure.asistencias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.asistencias.Persistence
{
    internal class MarcasMySqlContext : DbContext
    {
        public DbSet<MarcasMySQL> Asistencias { get; set; }

        public MarcasMySqlContext(DbContextOptions<MarcasMySqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AsistenciaConfig());
        }
    }

    internal sealed class AsistenciaConfig : IEntityTypeConfiguration<MarcasMySQL>
    {
        public void Configure(EntityTypeBuilder<MarcasMySQL> builder)
        {
            builder.ToTable("asistencias");
            builder.HasNoKey();
        }
    }
}
