using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.RetencionesCatalogo;

namespace LAUCHA.infrastructure.config.RetencionesCatalogo
{
    internal class CatalogoRetencionConfig : IEntityTypeConfiguration<CatalogoRetencion>
    {

        public void Configure(EntityTypeBuilder<CatalogoRetencion> builder)
        {
            builder.HasKey(rc => rc.Codigo);

            builder
           .HasMany<RetencionAcuerdo>()                   
           .WithOne()                                    
           .HasForeignKey(ra => ra.CodigoRetencion)       
           .HasPrincipalKey(rc => rc.Codigo)              
           .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
