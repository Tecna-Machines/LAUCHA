using LAUCHA.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.config
{
    internal class AdicionalesPorContratoConfig : IEntityTypeConfiguration<AdicionalPorContrato>
    {
        public void Configure(EntityTypeBuilder<AdicionalPorContrato> builder)
        {
            builder.HasKey(adicionalPorContrato => new { adicionalPorContrato.CodigoContrato, adicionalPorContrato.CodigoAdicional });

            builder.HasOne(adicionalPorContrato => adicionalPorContrato.Adicional)
                .WithMany(adicional => adicional.AdicionalesPorContrato)
                .HasForeignKey(adicionalPorContrato => adicionalPorContrato.CodigoAdicional);

            builder.HasOne(adicionalPorContrato => adicionalPorContrato.Contrato)
               .WithMany(contrato => contrato.AdicionalesPorContratos)
               .HasForeignKey(adicionalPorContrato => adicionalPorContrato.CodigoContrato);
        }
    }
}
