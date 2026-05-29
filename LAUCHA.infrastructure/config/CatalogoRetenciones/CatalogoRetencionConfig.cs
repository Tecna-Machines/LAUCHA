namespace LAUCHA.infrastructure.config.RetencionesCatalogo
{
    internal class CatalogoRetencionConfig : IEntityTypeConfiguration<CatalogoRetencion>
    {

        public void Configure(EntityTypeBuilder<CatalogoRetencion> builder)
        {
            builder.HasKey(rc => rc.Codigo);
            builder.Property(rc => rc.Codigo)
                    .HasMaxLength(100);    

            builder
           .HasMany<RetencionAcuerdo>()
           .WithOne()
           .HasForeignKey(ra => ra.CodigoRetencion)
           .HasPrincipalKey(rc => rc.Codigo)
           .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
