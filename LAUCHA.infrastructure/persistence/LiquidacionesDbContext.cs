using LAUCHA.domain.entities;
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

        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<DescuentoFijo> DescuentosFijos { get; set; }
        public DbSet<DescuentoFijoPorCuenta> DescuentosFijoPorCuentas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<HistorialDescuentoFijo> HistorialDescuentosFijos { get; set; }
        public DbSet<Liquidacion> Liquidaciones { get; set; }
        public DbSet<LiquidacionPorTransaccion> LiquidacionesPorTransacciones { get; set; }
        public DbSet<PagoLiquidacion> PagosLiquidaciones { get; set; }
        public DbSet<Subcuota> Subcuotas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContratoConfig());
            modelBuilder.ApplyConfiguration(new CreditoConfig());
            modelBuilder.ApplyConfiguration(new CuentaConfig());
            modelBuilder.ApplyConfiguration(new CuotaConfig());
            modelBuilder.ApplyConfiguration(new DescuentoFijoPorCuentaConfig());
            modelBuilder.ApplyConfiguration(new DescuentosFijosConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
            modelBuilder.ApplyConfiguration(new HistorialDescuentosFijosConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionPorTransaccionConfig());
            modelBuilder.ApplyConfiguration(new PagoConfig());
            modelBuilder.ApplyConfiguration(new SubcuotaConfig());
            modelBuilder.ApplyConfiguration(new TransaccionConfig());
        }
    }
}
