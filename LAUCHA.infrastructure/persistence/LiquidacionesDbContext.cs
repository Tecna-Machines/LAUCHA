using LAUCHA.domain.entities;
using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.infrastructure.config;
using LAUCHA.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<PagoCredito> PagosCreditos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
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
        public DbSet<NoRemuneracion> NoRemuneraciones { get; set; }
        public DbSet<NoRemuneracionPorLiquidacionPersonal> NoRemuneracionesPorLiquidaciones { get; set; }
        public DbSet<Retencion> Retenciones { get; set; }
        public DbSet<RetencionFija> RetencionesFijas { get; set; }
        public DbSet<RetencionFijaPorCuenta> RetencionesFijasPorCuentas { get; set; }
        public DbSet<RetencionPorLiquidacionPersonal> RetencionesPorLiquidaciones { get; set; }

        //DbSet de dias especiales
        public DbSet<AvisosAusencia> AvisosAusencia { get; set; }
        public DbSet<DiaFeriado> DiasFeriados { get; set; }
        public DbSet<PeriodoVacaciones> PeriodoVacaciones { get; set; }
        public DbSet<HabilitacionHorasExtra> HabilitacionHorasExtra { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcuerdoBlancoConfig());
            modelBuilder.ApplyConfiguration(new AdicionalConfig());
            modelBuilder.ApplyConfiguration(new AdicionalesPorContratoConfig());
            modelBuilder.ApplyConfiguration(new ConceptoConfig());
            modelBuilder.ApplyConfiguration(new ContratoConfig());
            modelBuilder.ApplyConfiguration(new CreditoConfig());
            modelBuilder.ApplyConfiguration(new CuentaConfig());
            modelBuilder.ApplyConfiguration(new DescuentoConfig());
            modelBuilder.ApplyConfiguration(new DescuentoPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
            modelBuilder.ApplyConfiguration(new HistorialRetencionFijaConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionConfig());
            modelBuilder.ApplyConfiguration(new LiquidacionGeneralConfig());
            modelBuilder.ApplyConfiguration(new ModalidadConfig());
            modelBuilder.ApplyConfiguration(new ModalidadPorContratoConfig());
            modelBuilder.ApplyConfiguration(new NoRemuneracionConfig());
            modelBuilder.ApplyConfiguration(new NoRemuneracionPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new PagoConfig());
            modelBuilder.ApplyConfiguration(new PagoCreditoConfig());
            modelBuilder.ApplyConfiguration(new RemuneracionConfig());
            modelBuilder.ApplyConfiguration(new RemuneracionPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new RetencionConfig());
            modelBuilder.ApplyConfiguration(new RetencionesFijasPorCuentaConfig());
            modelBuilder.ApplyConfiguration(new RetencionesPorLiquidacionConfig());
            modelBuilder.ApplyConfiguration(new RetencionFijaConfig());

            //agregar datos de prueba
            // TODO: son datos solo para pruebas 
            modelBuilder.ApplyConfiguration(new AdicionalData());
            modelBuilder.ApplyConfiguration(new CuentaData());
            modelBuilder.ApplyConfiguration(new EmpleadosData());
            modelBuilder.ApplyConfiguration(new ModalidadData());
            modelBuilder.ApplyConfiguration(new RetencionesFijasData());

            //configuracion dias especiales
            modelBuilder.ApplyConfiguration(new DiasFeriadosConfig());
            modelBuilder.ApplyConfiguration(new PeriodoVacacionesConfig());
            modelBuilder.ApplyConfiguration(new AvisosAusenciaConfig());
            modelBuilder.ApplyConfiguration(new HabilitacionHorasExtraConfig());


        }
    }
}
