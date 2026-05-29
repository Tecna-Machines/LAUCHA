namespace LAUCHA.infrastructure.config.Empleados
{
    internal class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(empleado => empleado.Dni);

            builder.HasIndex(emp => emp.Cuil)
                    .IsUnique();
            
            builder.Property(emp => emp.Dni)
                    .HasMaxLength(80);
            
            builder.Property(emp => emp.Cuil)
                    .HasMaxLength(80)
                    .IsRequired();


        }
    }
}
