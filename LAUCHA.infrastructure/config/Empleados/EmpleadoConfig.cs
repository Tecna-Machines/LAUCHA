namespace LAUCHA.infrastructure.config.Empleados
{
    internal class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(empleado => empleado.Dni);


        }
    }
}
