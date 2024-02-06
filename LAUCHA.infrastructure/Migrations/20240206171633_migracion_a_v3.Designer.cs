﻿// <auto-generated />
using System;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LAUCHA.infrastructure.Migrations
{
    [DbContext(typeof(LiquidacionesDbContext))]
    [Migration("20240206171633_migracion_a_v3")]
    partial class migracion_a_v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LAUCHA.domain.entities.AcuerdoBlanco", b =>
                {
                    b.Property<string>("CodigoAcuerdoBlanco")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoContrato")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EsPorcentual")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Unidades")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoAcuerdoBlanco");

                    b.HasIndex("CodigoContrato")
                        .IsUnique();

                    b.ToTable("AcuerdosBlancos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Adicional", b =>
                {
                    b.Property<string>("CodigoAdicional")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EsPorcentual")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Unidades")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoAdicional");

                    b.ToTable("Adicionales");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.AdicionalPorContrato", b =>
                {
                    b.Property<string>("CodigoContrato")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoAdicional")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoContrato", "CodigoAdicional");

                    b.HasIndex("CodigoAdicional");

                    b.ToTable("AdicionalesPorContrato");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Concepto", b =>
                {
                    b.Property<int>("NumeroConcepto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreConcepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("NumeroConcepto");

                    b.ToTable("Conceptos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Contrato", b =>
                {
                    b.Property<string>("CodigoContrato")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DniEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("FechaContrato")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MontoFijo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MontoPorHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoContrato")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodigoContrato");

                    b.HasIndex("DniEmpleado");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Credito", b =>
                {
                    b.Property<string>("CodigoCredito")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumeroConcepto")
                        .HasColumnType("int");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoCredito");

                    b.HasIndex("NumeroConcepto");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Creditos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuenta", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DniEmpleado")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("estadoCuenta")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("NumeroCuenta");

                    b.HasIndex("DniEmpleado")
                        .IsUnique();

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuota", b =>
                {
                    b.Property<string>("CodigoCuota")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoCredito")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaDebePagar")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoCuota");

                    b.HasIndex("CodigoCredito");

                    b.ToTable("Cuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.CuotaPorLiquidacionPersonal", b =>
                {
                    b.Property<string>("CodigoCuota")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoLiquidacion")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoCuota", "CodigoLiquidacion");

                    b.HasIndex("CodigoLiquidacion");

                    b.ToTable("CuotasPorLiquidacionPersonal");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Descuento", b =>
                {
                    b.Property<string>("CodigoDescuento")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumeroConcepto")
                        .HasColumnType("int");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoDescuento");

                    b.HasIndex("NumeroConcepto");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Descuentos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.DescuentoPorLiquidacionPersonal", b =>
                {
                    b.Property<string>("CodigoDescuento")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoLiquidacionPersonal")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoDescuento", "CodigoLiquidacionPersonal");

                    b.HasIndex("CodigoLiquidacionPersonal");

                    b.ToTable("DescuentosPorLiquidaciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Empleado", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Dni");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.HistorialRetencionFija", b =>
                {
                    b.Property<string>("CodigoRetencionFija")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaFinVigencia")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EsPorcentual")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Unidades")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoRetencionFija", "FechaFinVigencia");

                    b.ToTable("HistorialRetencionesFijas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.LiquidacionGeneral", b =>
                {
                    b.Property<string>("CodigoLiquidacionGeneral")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FinPeriodo")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InicioPeriodo")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TotalDescuentos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalRemuneracion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalRetencion")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoLiquidacionGeneral");

                    b.ToTable("LiquidacionesGenerales");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.LiquidacionPersonal", b =>
                {
                    b.Property<string>("CodigoLiquidacion")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoLiquidacionGeneral")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FinPeriodo")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("InicioPeriodo")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TotalDescuentos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalRemuneraciones")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalRetenciones")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoLiquidacion");

                    b.HasIndex("CodigoLiquidacionGeneral");

                    b.ToTable("LiquidacionesPersonales");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Modalidad", b =>
                {
                    b.Property<string>("CodigoModalidad")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodigoModalidad");

                    b.ToTable("Modalidades");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.ModalidadPorContrato", b =>
                {
                    b.Property<string>("CodigoModalidad")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoContrato")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoModalidad", "CodigoContrato");

                    b.HasIndex("CodigoContrato");

                    b.ToTable("ModalidadesPorContrato");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.PagoLiquidacion", b =>
                {
                    b.Property<int>("CodigoPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoLiquidacion")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoPago");

                    b.HasIndex("CodigoLiquidacion");

                    b.ToTable("PagosLiquidaciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Remuneracion", b =>
                {
                    b.Property<string>("CodigoRemuneracion")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EsBlanco")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoRemuneracion");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Remuneraciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RemuneracionPorLiquidacionPersonal", b =>
                {
                    b.Property<string>("CodigoRemuneracion")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoLiquidacionPersonal")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoRemuneracion", "CodigoLiquidacionPersonal");

                    b.HasIndex("CodigoLiquidacionPersonal");

                    b.ToTable("RemuneracionesPorLiquidaciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Retencion", b =>
                {
                    b.Property<string>("CodigoRetencion")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoRetencion");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Retenciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RetencionFija", b =>
                {
                    b.Property<string>("CodigoRetencionFija")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EsPorcentual")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Unidades")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoRetencionFija");

                    b.ToTable("RetencionesFijas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RetencionFijaPorCuenta", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoRetencionFija")
                        .HasColumnType("varchar(255)");

                    b.HasKey("NumeroCuenta", "CodigoRetencionFija");

                    b.HasIndex("CodigoRetencionFija");

                    b.ToTable("RetencionesFijasPorCuentas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RetencionPorLiquidacionPersonal", b =>
                {
                    b.Property<string>("CodigoRetencion")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoLiquidacionPersonal")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoRetencion", "CodigoLiquidacionPersonal");

                    b.HasIndex("CodigoLiquidacionPersonal");

                    b.ToTable("RetencionesPorLiquidaciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.SubCuotaPorLiquidacion", b =>
                {
                    b.Property<string>("CodigoSubcuota")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoLiquidacion")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CodigoSubcuota", "CodigoLiquidacion");

                    b.HasIndex("CodigoLiquidacion");

                    b.ToTable("SubcuotasPorLiquidacion");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Subcuota", b =>
                {
                    b.Property<string>("CodigoSubcuota")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CodigoCuota")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("FechaDebePagar")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodigoSubcuota");

                    b.HasIndex("CodigoCuota");

                    b.ToTable("Subcuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.AcuerdoBlanco", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Contrato", "Contrato")
                        .WithOne("AcuerdoBlanco")
                        .HasForeignKey("LAUCHA.domain.entities.AcuerdoBlanco", "CodigoContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.AdicionalPorContrato", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Adicional", "Adicional")
                        .WithMany("AdicionalesPorContrato")
                        .HasForeignKey("CodigoAdicional")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Contrato", "Contrato")
                        .WithMany("AdicionalesPorContratos")
                        .HasForeignKey("CodigoContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adicional");

                    b.Navigation("Contrato");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Contrato", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Empleado", "Empleado")
                        .WithMany("Contratos")
                        .HasForeignKey("DniEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Credito", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Concepto", "Concepto")
                        .WithMany("Creditos")
                        .HasForeignKey("NumeroConcepto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("Creditos")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concepto");

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuenta", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Empleado", "Empleado")
                        .WithOne("Cuenta")
                        .HasForeignKey("LAUCHA.domain.entities.Cuenta", "DniEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuota", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Credito", "Credito")
                        .WithMany("Cuotas")
                        .HasForeignKey("CodigoCredito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credito");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.CuotaPorLiquidacionPersonal", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Cuota", "Cuota")
                        .WithMany("CuotasPorLiquidaciones")
                        .HasForeignKey("CodigoCuota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.LiquidacionPersonal", "LiquidacionPersonal")
                        .WithMany("CuotasPorLiquidaciones")
                        .HasForeignKey("CodigoLiquidacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuota");

                    b.Navigation("LiquidacionPersonal");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Descuento", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Concepto", "Concepto")
                        .WithMany("Descuentos")
                        .HasForeignKey("NumeroConcepto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("Descuentos")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concepto");

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.DescuentoPorLiquidacionPersonal", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Descuento", "Descuento")
                        .WithMany("DescuentoPorLiquidacionPersonales")
                        .HasForeignKey("CodigoDescuento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.LiquidacionPersonal", "LiquidacionPersonal")
                        .WithMany("DescuentoPorLiquidacionPersonales")
                        .HasForeignKey("CodigoLiquidacionPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Descuento");

                    b.Navigation("LiquidacionPersonal");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.HistorialRetencionFija", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.RetencionFija", "RetencionFija")
                        .WithMany("HistorialRetencionesFijas")
                        .HasForeignKey("CodigoRetencionFija")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RetencionFija");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.LiquidacionPersonal", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.LiquidacionGeneral", "LiquidacionGeneral")
                        .WithMany("LiquidacionesPersonales")
                        .HasForeignKey("CodigoLiquidacionGeneral")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiquidacionGeneral");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.ModalidadPorContrato", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Contrato", "Contrato")
                        .WithMany("ModalidadesPorContratos")
                        .HasForeignKey("CodigoContrato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Modalidad", "Modalidad")
                        .WithMany("ModalidadesPorContratos")
                        .HasForeignKey("CodigoModalidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrato");

                    b.Navigation("Modalidad");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.PagoLiquidacion", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.LiquidacionPersonal", "Liquidacion")
                        .WithMany("PagosLiquidacion")
                        .HasForeignKey("CodigoLiquidacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Liquidacion");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Remuneracion", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("Remuneraciones")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RemuneracionPorLiquidacionPersonal", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.LiquidacionPersonal", "LiquidacionPersonal")
                        .WithMany("RemuneracionPorLiquidacionPersonales")
                        .HasForeignKey("CodigoLiquidacionPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Remuneracion", "Remuneracion")
                        .WithMany("RemuneracionPorLiquidacionPersonales")
                        .HasForeignKey("CodigoRemuneracion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiquidacionPersonal");

                    b.Navigation("Remuneracion");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Retencion", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("Retenciones")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RetencionFijaPorCuenta", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.RetencionFija", "RetencionFija")
                        .WithMany("RetencionesFijasPorCuenta")
                        .HasForeignKey("CodigoRetencionFija")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Cuenta", "Cuenta")
                        .WithMany("RetencionesFijasPorCuenta")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");

                    b.Navigation("RetencionFija");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RetencionPorLiquidacionPersonal", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.LiquidacionPersonal", "LiquidacionPersonal")
                        .WithMany("RetencionPorLiquidacionPersonales")
                        .HasForeignKey("CodigoLiquidacionPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Retencion", "Retencion")
                        .WithMany("RetencionPorLiquidacionPersonales")
                        .HasForeignKey("CodigoRetencion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiquidacionPersonal");

                    b.Navigation("Retencion");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.SubCuotaPorLiquidacion", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.LiquidacionPersonal", "LiquidacionPersonal")
                        .WithMany("SubCuotasPorLiquidaciones")
                        .HasForeignKey("CodigoLiquidacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAUCHA.domain.entities.Subcuota", "Subcuota")
                        .WithMany("SubCuotasPorLiquidaciones")
                        .HasForeignKey("CodigoLiquidacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiquidacionPersonal");

                    b.Navigation("Subcuota");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Subcuota", b =>
                {
                    b.HasOne("LAUCHA.domain.entities.Cuota", "Cuota")
                        .WithMany("Subcuotas")
                        .HasForeignKey("CodigoCuota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuota");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Adicional", b =>
                {
                    b.Navigation("AdicionalesPorContrato");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Concepto", b =>
                {
                    b.Navigation("Creditos");

                    b.Navigation("Descuentos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Contrato", b =>
                {
                    b.Navigation("AcuerdoBlanco")
                        .IsRequired();

                    b.Navigation("AdicionalesPorContratos");

                    b.Navigation("ModalidadesPorContratos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Credito", b =>
                {
                    b.Navigation("Cuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuenta", b =>
                {
                    b.Navigation("Creditos");

                    b.Navigation("Descuentos");

                    b.Navigation("Remuneraciones");

                    b.Navigation("Retenciones");

                    b.Navigation("RetencionesFijasPorCuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Cuota", b =>
                {
                    b.Navigation("CuotasPorLiquidaciones");

                    b.Navigation("Subcuotas");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Descuento", b =>
                {
                    b.Navigation("DescuentoPorLiquidacionPersonales");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Empleado", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("Cuenta")
                        .IsRequired();
                });

            modelBuilder.Entity("LAUCHA.domain.entities.LiquidacionGeneral", b =>
                {
                    b.Navigation("LiquidacionesPersonales");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.LiquidacionPersonal", b =>
                {
                    b.Navigation("CuotasPorLiquidaciones");

                    b.Navigation("DescuentoPorLiquidacionPersonales");

                    b.Navigation("PagosLiquidacion");

                    b.Navigation("RemuneracionPorLiquidacionPersonales");

                    b.Navigation("RetencionPorLiquidacionPersonales");

                    b.Navigation("SubCuotasPorLiquidaciones");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Modalidad", b =>
                {
                    b.Navigation("ModalidadesPorContratos");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Remuneracion", b =>
                {
                    b.Navigation("RemuneracionPorLiquidacionPersonales");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Retencion", b =>
                {
                    b.Navigation("RetencionPorLiquidacionPersonales");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.RetencionFija", b =>
                {
                    b.Navigation("HistorialRetencionesFijas");

                    b.Navigation("RetencionesFijasPorCuenta");
                });

            modelBuilder.Entity("LAUCHA.domain.entities.Subcuota", b =>
                {
                    b.Navigation("SubCuotasPorLiquidaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
