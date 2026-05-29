namespace LAUCHA.infrastructure.config
{
    internal class AdicionalConfig : IEntityTypeConfiguration<Adicional>
    {
        public void Configure(EntityTypeBuilder<Adicional> builder)
        {
            builder.HasKey(adi => adi.Codigo);

            builder.Property(adi => adi.Codigo)
                    .HasMaxLength(40);
        }
    }
}
