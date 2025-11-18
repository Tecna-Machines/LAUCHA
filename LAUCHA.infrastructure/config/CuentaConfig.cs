using LAUCHA.domain.entities;

namespace LAUCHA.infrastructure.config
{
    internal class CuentaConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(cuenta => cuenta.NumeroCuenta);

            builder.HasOne(cuenta => cuenta.Empleado)
                .WithOne(empleado => empleado.Cuenta)
                .HasForeignKey<Cuenta>(cuenta => cuenta.DniEmpleado);
        }
    }
}
