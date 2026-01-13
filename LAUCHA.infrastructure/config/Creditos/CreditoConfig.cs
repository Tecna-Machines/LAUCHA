namespace LAUCHA.infrastructure.config.Creditos
{
    internal class CreditoConfig : IEntityTypeConfiguration<Credito>
    {
        public void Configure(EntityTypeBuilder<Credito> builder)
        {
            builder.HasKey(credito => credito.Codigo);


            builder.Property(c => c.DniEmpleado)
              .IsRequired();

            builder.HasOne<Empleado>()
              .WithMany()
              .HasForeignKey(c => c.DniEmpleado)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Liquidacion>()
                .WithMany()
                .HasForeignKey(c => c.CodigoLiquidacionAcreditacion)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
