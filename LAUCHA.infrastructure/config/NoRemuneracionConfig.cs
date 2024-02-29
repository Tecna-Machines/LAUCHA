using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class NoRemuneracionConfig : IEntityTypeConfiguration<NoRemuneracion>
    {
        public void Configure(EntityTypeBuilder<NoRemuneracion> builder)
        {
            builder.HasKey(NoRemu => NoRemu.CodigoNoRemuneracion);

            builder.HasOne(Noremuneracion => Noremuneracion.Cuenta)
                   .WithMany(cuenta => cuenta.NoRemuneraciones)
                   .HasForeignKey(Noremuneracion => Noremuneracion.NumeroCuenta);

        }
    }
}
