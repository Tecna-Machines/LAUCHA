using LAUCHA.domain.entities.diasEspeciales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.config
{
    internal class HabilitacionHorasExtraConfig : IEntityTypeConfiguration<HabilitacionHorasExtra>
    {
        public void Configure(EntityTypeBuilder<HabilitacionHorasExtra> builder)
        {
            builder.HasKey(hhe => new { hhe.DniEmpleado, hhe.FechaInicio });

            builder.HasOne(hhe => hhe.Empleado)
                .WithMany(e => e.HabilitacionesHorasExtra)
                .HasForeignKey(hhe => hhe.DniEmpleado)
                .OnDelete(DeleteBehavior.Restrict); // Evita el borrado en cascada

            builder.HasOne(hhe => hhe.Responsable)
                .WithMany()
                .HasForeignKey(hhe => hhe.DniResponsable)
                .OnDelete(DeleteBehavior.Restrict); // Evita el borrado en cascada

            builder.Property(hhe => hhe.FechaInicio)
                .IsRequired();

            builder.Property(hhe => hhe.FechaFin)
                .IsRequired();
        }
    }
}
