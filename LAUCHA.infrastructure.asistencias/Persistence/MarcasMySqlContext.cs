using LAUCHA.domain.Entities.Feriados;
using LAUCHA.infrastructure.asistencias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.asistencias.Persistence
{
    internal class MarcasMySqlContext : DbContext
    {
        public DbSet<MarcasMySQL> Asistencias { get; set; }
        public DbSet<Feriado> Feriados { get; set; }

        public MarcasMySqlContext(DbContextOptions<MarcasMySqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AsistenciaConfig());
            modelBuilder.ApplyConfiguration(new FeriadoConfig());
        }
    }

    internal sealed class AsistenciaConfig : IEntityTypeConfiguration<MarcasMySQL>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MarcasMySQL> builder)
        {
            builder.ToTable("asistencias");
            builder.HasNoKey();
        }
    }
    internal sealed class FeriadoConfig : IEntityTypeConfiguration<Feriado>
    {
        public void Configure(EntityTypeBuilder<Feriado> builder)
        {
            builder.ToTable("feriados");
            builder.HasKey(f => f.Fecha);
        }

    }
}
