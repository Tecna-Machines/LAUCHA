using LAUCHA.domain.Entities.Pagos;
using LAUCHA.infrastructure.config.Empleados;
using LAUCHA.infrastructure.Config.Liquidaciones;

namespace LAUCHA.infrastructure.persistence
{
    public class LiquidacionesDbContext : DbContext
    {
        public LiquidacionesDbContext(DbContextOptions<LiquidacionesDbContext> options) : base(options) { }

        public LiquidacionesDbContext() { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Adicional> Adicionales { get; set; }
        public DbSet<Acuerdo> Acuerdos { get; set; }
        public DbSet<RetencionAcuerdo> RetencionAcuerdo { get; set; }
        public DbSet<CatalogoRetencion> CatalogoRetenciones { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<CuotaCredito> Cuotas { get; set; }
        public DbSet<Liquidacion> Liquidaciones { get; set; }
        public DbSet<Pago> PagosLiquidacion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcuerdoConfig());
            modelBuilder.ApplyConfiguration(new CatalogoRetencionConfig());


            modelBuilder.ApplyConfiguration(new AdicionalConfig());
            modelBuilder.ApplyConfiguration(new RetencionAcuerdoConfig());

            modelBuilder.ApplyConfiguration(new CreditoConfig());
            modelBuilder.ApplyConfiguration(new CuotaCreditoConfig());

            modelBuilder.ApplyConfiguration(new EmpleadoConfig());

            modelBuilder.ApplyConfiguration(new LiquidacionConfig());
            modelBuilder.ApplyConfiguration(new PagoConfig());
            modelBuilder.ApplyConfiguration(new RetencionFijaConfig());
            modelBuilder.ApplyConfiguration(new ItemLiquidacionConfig());


        }

    }
}
