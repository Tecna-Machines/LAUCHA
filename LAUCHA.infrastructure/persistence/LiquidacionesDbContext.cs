﻿using LAUCHA.domain.entities;
using LAUCHA.infrastructure.config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.persistence
{
    public class LiquidacionesDbContext : DbContext
    {
        public LiquidacionesDbContext(DbContextOptions<LiquidacionesDbContext> options) : base(options) { }

        public DbSet<AcuerdoBlanco> AcuerdosBlancos { get; set; }
        public DbSet<Adicional> Adicionales { get; set; }
        public DbSet<AdicionalPorContrato> AdicionalesPorContrato { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<CuotaPorLiquidacionPersonal> CuotasPorLiquidacionPersonal { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<DescuentoPorLiquidacionPersonal> DescuentosPorLiquidaciones { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<HistorialRetencionFija> HistorialRetencionesFijas { get; set; }
        public DbSet<LiquidacionGeneral> LiquidacionesGenerales { get; set; }
        public DbSet<LiquidacionPersonal> LiquidacionesPersonales { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
        public DbSet<ModalidadPorContrato> ModalidadesPorContrato { get; set; }
        public DbSet<PagoLiquidacion> PagosLiquidaciones { get; set; }
        public DbSet<Remuneracion> Remuneraciones { get; set; }
        public DbSet<RemuneracionPorLiquidacionPersonal> RemuneracionesPorLiquidaciones { get; set; }
        public DbSet<Retencion> Retenciones { get; set; }
        public DbSet<RetencionFija> RetencionesFijas { get; set; }
        public DbSet<RetencionFijaPorCuenta> RetencionesFijasPorCuentas { get; set; }
        public DbSet<RetencionPorLiquidacionPersonal> RetencionesPorLiquidaciones { get; set; }
        public DbSet<Subcuota> Subcuotas { get; set; }
        public DbSet<SubCuotaPorLiquidacion> SubcuotasPorLiquidacion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcuerdoBlancoConfig());
            modelBuilder.ApplyConfiguration(new AdicionalConfig());
            modelBuilder.ApplyConfiguration(new AdicionalesPorContratoConfig());
            modelBuilder.ApplyConfiguration(new ConceptoConfig());
            modelBuilder.ApplyConfiguration(new ContratoConfig());
            modelBuilder.ApplyConfiguration(new CreditoConfig());
            modelBuilder.ApplyConfiguration(new CuentaConfig());
            modelBuilder.ApplyConfiguration(new CuotaConfig());
            modelBuilder.ApplyConfiguration(new CuotaPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new DescuentoConfig());
            modelBuilder.ApplyConfiguration(new DescuentoPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
            modelBuilder.ApplyConfiguration(new HistorialRetencionFijaConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionGeneralConfig());
            modelBuilder.ApplyConfiguration(new ModalidadConfig());
            modelBuilder.ApplyConfiguration(new ModalidadPorContratoConfig());
            modelBuilder.ApplyConfiguration(new PagoConfig());
            modelBuilder.ApplyConfiguration(new RemuneracionConfig());
            modelBuilder.ApplyConfiguration(new RemuneracionPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new RetencionConfig());
            modelBuilder.ApplyConfiguration(new RetencionesFijasPorCuentaConfig());
            modelBuilder.ApplyConfiguration(new RetencionesPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new RetencionFijaConfig());
            modelBuilder.ApplyConfiguration(new SubcuotaConfig());
            modelBuilder.ApplyConfiguration(new SubcuotaPorLiquidacionConfig());

        }
    }
}
