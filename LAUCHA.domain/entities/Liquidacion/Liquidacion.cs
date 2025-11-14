using LAUCHA.domain.entities;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;
using System.Collections.Immutable;

namespace LAUCHA.domain.Entities.Liquidacion
{
    public class Liquidacion
    {
        public string Codigo { get; set; } = null!;
        public string DniEmpleado { get; set; } = null!;
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Quincena { get; set; }
        public string CodigoAcuerdo { get; set; } = null!;
        public Acuerdo Acuerdo { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaSello { get; set; }

        public EstadoLiquidacion Estado { get; set; }
        public ICollection<ItemLiquidacion> Items { get; set; } = null!;

        public static Liquidacion IniciarLiquidacion(Empleado emp, int anio, int mes, int quincena)
        {
            return new Liquidacion
            {
                Codigo = GenerarCodigo(emp.Dni, anio, mes, quincena),
                DniEmpleado = emp.Dni,
                Anio = anio,
                Mes = mes,
                Quincena = quincena,
                FechaCreacion = DateTime.Now,
                Items = new List<ItemLiquidacion>()
            };
        }
        public void AgregarItem(ItemLiquidacion item)
        {
            if (Estado != EstadoLiquidacion.SELLADA)
            {
                item.AsociarLiquidacion(this);
                Items.Add(item);
            }
        }

        public IEnumerable<ItemLiquidacion> GetItems() => Items.ToImmutableList();

        public void Sellar()
        {
            if (Estado == EstadoLiquidacion.PENDIENTE)
            {
                Estado = EstadoLiquidacion.SELLADA;
                FechaSello = DateTime.Now;
            }
        }

        private static string GenerarCodigo(string dni, int anio, int mes, int quincena)
            => $"{anio}:{mes}:{quincena}:{dni}";

        public decimal TotalRemuneraciones { get; set; }
        public decimal TotalNoRemunerativo { get; set; }
        public decimal TotalRetenciones { get; set; }
        public decimal TotalDescuentos { get; set; }
        public string Concepto { get; set; } = null!;
        public DateTime FechaLiquidacion { get; set; }
        public DateTime InicioPeriodo { get; set; }
        public DateTime FinPeriodo { get; set; }
        public ICollection<PagoLiquidacion> PagosLiquidacion { get; set; } = null!;
        public IList<RemuneracionPorLiquidacionPersonal> RemuneracionPorLiquidacionPersonales { get; set; } = null!;
        public IList<RetencionPorLiquidacionPersonal> RetencionPorLiquidacionPersonales { get; set; } = null!;
        public IList<DescuentoPorLiquidacionPersonal> DescuentoPorLiquidacionPersonales { get; set; } = null!;
        public IList<NoRemuneracionPorLiquidacionPersonal> NoRemuneracionesPorLiquidaciones { get; set; } = null!;

        public string? CodigoLiquidacionGeneral { get; set; }
        public LiquidacionGeneral? LiquidacionGeneral;


    }
}
