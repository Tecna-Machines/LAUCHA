using LAUCHA.domain.entities;

namespace LAUCHA.infrastructure.config
{
    internal class RemuneracionConfig : IEntityTypeConfiguration<Remuneracion>
    {
        public void Configure(EntityTypeBuilder<Remuneracion> builder)
        {
            builder.HasKey(remuneracion => remuneracion.CodigoRemuneracion);

            builder.HasOne(remuneracion => remuneracion.Cuenta)
                    .WithMany(cuenta => cuenta.Remuneraciones)
                    .HasForeignKey(remuneracion => remuneracion.NumeroCuenta);
        }
    }
}
