using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAUCHA.infrastructure.config
{
    internal class ModalidadPorContratoConfig : IEntityTypeConfiguration<ModalidadPorContrato>
    {
        public void Configure(EntityTypeBuilder<ModalidadPorContrato> builder)
        {
            builder.HasKey(modalidadPorContrato =>
                           new { modalidadPorContrato.CodigoModalidad, modalidadPorContrato.CodigoContrato });

            builder.HasOne(modalidadPorContrato => modalidadPorContrato.Modalidad)
                    .WithMany(modalidad => modalidad.ModalidadesPorContratos)
                    .HasForeignKey(modalidadPorContrato => modalidadPorContrato.CodigoModalidad);


            builder.HasOne(modalidadPorContrato => modalidadPorContrato.Contrato)
                    .WithMany(modalidad => modalidad.ModalidadesPorContratos)
                    .HasForeignKey(modalidadPorContrato => modalidadPorContrato.CodigoContrato);
        }
    }
}
