using LAUCHA.domain.entities;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;
using System.Collections.Immutable;

namespace LAUCHA.domain.Entities.Liquidaciones
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
                Concepto = $"{quincena} quincena {mes}/{anio} : {emp.Nombre}{emp.Apellido}",
                FechaCreacion = DateTime.Now,
                Items = new List<ItemLiquidacion>()
            };
        }
        public void AgregarItem(ItemLiquidacion item)
        {
            if (Estado != EstadoLiquidacion.SELLADA)
            {
                item.CodigoLiquidacion = Codigo;
                item.NroItem = Items.Count;
                Items.Add(item);
            }
        }

        public IEnumerable<ItemLiquidacion> GetItems() => Items.ToImmutableList();

        /// <summary>
        /// sellara una liquidacion lo que impide modificarla
        /// </summary>
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

        private IEnumerable<ItemLiquidacion> GetItemsRemunerativoBlanco()
        {
            return GetItems()
                   .Where(it => it.Tipo == TipoItemLiquidacion.Remunerativo
                    && it.EsEnBlanco);
        }

        public decimal CalcularSubTotalRemunerativoBlanco()
           => GetItemsRemunerativoBlanco().Sum(it => it.Monto);

        public bool EsPrimeraQuincena() => Quincena == 2 ? true : false;
        public bool EstaSellada() => Estado == EstadoLiquidacion.SELLADA ? true : false;

        public void SetAcuerdo(Acuerdo acuerdo)
        {
            Acuerdo = acuerdo;
            CodigoAcuerdo = acuerdo.Codigo;
        }

        //TODO: esto se deberia poder borrar
        public decimal TotalRemuneraciones { get; set; }
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
