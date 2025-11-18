using LAUCHA.domain.entities.diasEspeciales;

namespace LAUCHA.infrastructure.config
{
    internal class DiasFeriadosConfig : IEntityTypeConfiguration<DiaFeriado>
    {
        public void Configure(EntityTypeBuilder<DiaFeriado> builder)
        {
            builder.HasKey(df => df.FechaFeriado);
            builder.Property(df => df.Descripcion).IsRequired();
        }
    }
}
