using LAUCHA.infrastructure.config.Empleados;

namespace LAUCHA.infrastructure.persistence
{
    public class LiquidacionesDbContext : DbContext
    {
        public LiquidacionesDbContext(DbContextOptions<LiquidacionesDbContext> options) : base(options) { }

        public LiquidacionesDbContext() { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Adicional> Adicionales { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }
        public DbSet<Acuerdo> Acuerdos { get; set; }
        public DbSet<RetencionAcuerdo> RetencionAcuerdo { get; set; }
        public DbSet<CatalogoRetencion> CatalogoRetenciones { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<CuotaCredito> Cuotas { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<DescuentoPorLiquidacionPersonal> DescuentosPorLiquidaciones { get; set; }
        public DbSet<LiquidacionGeneral> LiquidacionesGenerales { get; set; }
        public DbSet<Liquidacion> Liquidaciones { get; set; }
        public DbSet<PagoLiquidacion> PagosLiquidaciones { get; set; }
        public DbSet<Remuneracion> Remuneraciones { get; set; }
        public DbSet<RemuneracionPorLiquidacionPersonal> RemuneracionesPorLiquidaciones { get; set; }
        public DbSet<NoRemuneracion> NoRemuneraciones { get; set; }
        public DbSet<NoRemuneracionPorLiquidacionPersonal> NoRemuneracionesPorLiquidaciones { get; set; }
        public DbSet<RetencionOLD> Retenciones { get; set; }
        public DbSet<RetencionPorLiquidacionPersonal> RetencionesPorLiquidaciones { get; set; }

        //DbSet de dias especiales
        public DbSet<AvisosAusencia> AvisosAusencia { get; set; }
        public DbSet<DiaFeriado> DiasFeriados { get; set; }
        public DbSet<PeriodoVacaciones> PeriodoVacaciones { get; set; }
        public DbSet<HabilitacionHorasExtra> HabilitacionHorasExtra { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcuerdoConfig());
            modelBuilder.ApplyConfiguration(new CatalogoRetencionConfig());


            modelBuilder.ApplyConfiguration(new AdicionalConfig());
            modelBuilder.ApplyConfiguration(new ConceptoConfig());
            modelBuilder.ApplyConfiguration(new RetencionAcuerdoConfig());

            modelBuilder.ApplyConfiguration(new CreditoConfig());
            modelBuilder.ApplyConfiguration(new CuotaCreditoConfig());

            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
            modelBuilder.ApplyConfiguration(new CuentaConfig());

            modelBuilder.ApplyConfiguration(new DescuentoConfig());
            modelBuilder.ApplyConfiguration(new DescuentoPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionGeneralConfig());
            modelBuilder.ApplyConfiguration(new NoRemuneracionConfig());
            modelBuilder.ApplyConfiguration(new RetencionConfig());
            modelBuilder.ApplyConfiguration(new NoRemuneracionPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new PagoConfig());
            modelBuilder.ApplyConfiguration(new RemuneracionConfig());
            modelBuilder.ApplyConfiguration(new RemuneracionPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new RetencionesPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new RetencionFijaConfig());
            modelBuilder.ApplyConfiguration(new ItemLiquidacionConfig());

            //agregar datos de prueba
            // TODO: son datos solo para pruebas 
            //modelBuilder.ApplyConfiguration(new AdicionalData());
            //modelBuilder.ApplyConfiguration(new CuentaData());
            //modelBuilder.ApplyConfiguration(new EmpleadosData());
            modelBuilder.ApplyConfiguration(new RetencionesFijasData());

            //configuracion dias especiales
            modelBuilder.ApplyConfiguration(new DiasFeriadosConfig());
            modelBuilder.ApplyConfiguration(new PeriodoVacacionesConfig());
            modelBuilder.ApplyConfiguration(new AvisosAusenciaConfig());
            modelBuilder.ApplyConfiguration(new HabilitacionHorasExtraConfig());


        }
    }
}
