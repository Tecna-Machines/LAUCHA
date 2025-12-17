namespace LAUCHA.infrastructure.config.Acuerdos
{
    internal class RetencionAcuerdoConfig : IEntityTypeConfiguration<RetencionAcuerdo>
    {
        public void Configure(EntityTypeBuilder<RetencionAcuerdo> builder)
        {
            builder.HasKey(ra => new { ra.CodigoRetencion, ra.CodigoAcuerdo });

            builder
            .HasOne<CatalogoRetencion>()
            .WithMany()
            .HasForeignKey(ra => ra.CodigoRetencion)
            .HasPrincipalKey(rc => rc.Codigo)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
