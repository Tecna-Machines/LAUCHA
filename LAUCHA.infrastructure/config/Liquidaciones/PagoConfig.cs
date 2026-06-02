using LAUCHA.domain.Entities.Pagos;

namespace LAUCHA.infrastructure.Config.Liquidaciones
{
    internal class PagoConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pagos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LiquidacionId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Monto)
                .HasColumnType("decimal(18,2)");
        }
    }
}
