namespace LAUCHA.infrastructure.config.Empleados
{
    internal class CuentaConfig : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(cuenta => cuenta.NumeroCuenta);

            builder.Property(c => c.DniEmpleado)
               .IsRequired();

            builder.HasIndex(c => c.DniEmpleado)
                   .IsUnique();

            builder.HasOne(c => c.Empleado)
                   .WithOne(e => e.Cuenta)
                   .HasForeignKey<Cuenta>(c => c.DniEmpleado)
                   .HasPrincipalKey<Empleado>(e => e.Dni)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
