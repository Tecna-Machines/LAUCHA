using LAUCHA.domain.interfaces.IServices;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.Services.Marcas.Persistence
{
    public class MarcaMySQL
    {
        public string IdPersonal { get; set; } // Suponiendo que DNI no es nulo
        public string NombreCompleto { get; set; } // Suponiendo que NombreCompleto no es nulo
        public DateTime Ingreso { get; set; } // Suponiendo que Ingreso no es nulo
        public DateTime? Egreso { get; set; } // Puede ser nulo
        public int? Tarde { get; set; } // Puede ser nulo
        public double HsTrabajadas { get; set; } // Suponiendo que no es nulo
        public double Minutos { get; set; } // Suponiendo que no es nulo
        public string Area { get; set; } // Puede ser nulo
    }

    public class MarcasDbContext : DbContext
    {
        public DbSet<MarcaMySQL> Marcas { get; set; }

        public MarcasDbContext(DbContextOptions<MarcasDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarcaMySQL>()
                .ToTable("asistencias");

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.IdPersonal)
                .HasColumnName("DNI")
                .IsRequired();

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.NombreCompleto)
                .HasColumnName("NombreCompleto")
                .IsRequired();

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.Ingreso)
                .HasColumnName("Ingreso")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.Egreso)
                .HasColumnName("Egreso");

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.Tarde)
                .HasColumnName("Tarde");

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.HsTrabajadas)
                .HasColumnName("HsTrabajadas");

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.Minutos)
                .HasColumnName("Minutos");

            modelBuilder.Entity<MarcaMySQL>()
                .Property(m => m.Area)
                .HasColumnName("Area");
        }


    }
}
