using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.infrastructure.config
{
    internal class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(empleado => empleado.Dni);

        }
    }
}
