using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.Entities.Pagos;
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
        public string Concepto { get; set; } = null!;
        public Acuerdo Acuerdo { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaSello { get; set; }

        public EstadoLiquidacion Estado { get; set; }
        public ICollection<ItemLiquidacion> Items { get; set; } = null!;
        public ICollection<Pago> Pagos { private set; get; } = null!;

        /// <summary>
        /// crea una liquidacion sin items
        /// </summary>
        public static Liquidacion GenerarSinItems(Empleado emp, int anio, int mes, int quincena)
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

        public IEnumerable<ItemLiquidacion> GetAllItems() => Items.ToImmutableList();
        public IEnumerable<ItemLiquidacion> GetItemsAceptados() => Items.Where(it => it.Estado != EstadoItemLiquidacion.ANULADO);

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

        private IEnumerable<ItemLiquidacion> GetItemsRemunerativoBlancoValido()
        {
            return GetItemsAceptados()
                   .Where(it => it.Tipo == TipoItemLiquidacion.Remunerativo
                    && it.EsEnBlanco);
        }

        public IEnumerable<ItemLiquidacion> GetItemsRetencionesAceptadas()
        => GetItemsAceptados()
           .Where(it => it.Tipo == TipoItemLiquidacion.Retencion && it.EsEnBlanco);


        public IEnumerable<ItemLiquidacion> GetItemsEnNegroAceptados()
            => GetItemsAceptados()
               .Where(it => !it.EsEnBlanco);

        //TODO: otra garcha para refactorizar
        public decimal CalcularNetoBlanco()
        {
            var remunerativoBlanco = GetItemsRemunerativoBlancoValido()
                                               .Sum(it => it.Monto);

            var noRemunerativoBlanco = GetItemsAceptados()
                                .Where(it =>
                                       it.Tipo == TipoItemLiquidacion.NoRemunerativo)
                                .Sum(it => it.Monto);

            decimal totalRemuneraiones = remunerativoBlanco + noRemunerativoBlanco;

            var montoRetenciones = GetItemsRetencionesAceptadas()
                                             .Sum(it => it.Monto);

            return totalRemuneraiones - montoRetenciones;
        }

        public decimal CalcularNetoNegro()
        {
            decimal plataQueEntraEnNegro = GetItemsEnNegroAceptados()
                                                             .Where(it => it.EsIncremento)
                                                             .Sum(it => it.Monto);

            decimal plataQueSaleEnNegro = GetItemsEnNegroAceptados()
                                                            .Where(it => !it.EsIncremento)
                                                            .Sum(it => it.Monto);

            return (plataQueEntraEnNegro - plataQueSaleEnNegro);
        }

        public bool EsPrimeraQuincena() => Quincena == 2 ? true : false;

        public bool EstaSellada() => Estado == EstadoLiquidacion.SELLADA ? true : false;

        public void SetAcuerdo(Acuerdo acuerdo)
        {
            Acuerdo = acuerdo;
            CodigoAcuerdo = acuerdo.Codigo;
        }

        /// <summary>
        /// reemplaza los items automaticos viejos por unos nuevos
        /// </summary>
        /// <param name="nuevosItems"></param>
        public void ReemplazarItemsAutomaticos(IEnumerable<ItemLiquidacion> nuevosItems)
        {
            if (EstaSellada())
                return;

            var itemsAutomaticos = GetItemsAceptados()
                                   .Where(it => !it.generadoPorUsuario)
                                   .ToList();

            foreach (var it in itemsAutomaticos)
            {
                Items.Remove(it);
            }

            foreach (var nuevoItem in nuevosItems)
            {
                nuevoItem.MarcarComoGeneradoPorElSistema();
                AgregarItem(nuevoItem);
            }
        }

        public void AgregarPago(Pago pago)
        {
            Pagos.Add(pago);
        }

        public decimal GetMontoPagado() => Pagos.Sum(p => p.Monto);

        public bool TieneImpactoContable()
        {
            return Pagos
                    .Any(p => p.EstadoContable == Pago.EstadoContabilidad.ENVIADO);
        }

        public string? ObtenerReferenciaContable()
        {
            return Pagos
                  .FirstOrDefault(p => p.ReferenciaContabilidad != null)?
                  .ReferenciaContabilidad;
        }

    }
}
