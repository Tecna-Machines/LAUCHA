using LAUCHA.domain.Entities.Liquidaciones;

namespace LAUCHA.domain.Entities.Creditos
{
    public class Credito
    {
        public string Codigo { get; private set; } = null!;
        public decimal MontoPrestado { get; private set; }
        public decimal MontoDevolver { get; private set; }
        public string DniEmpleado { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public string? CodigoLiquidacionAcreditacion { get; private set; }
        public DateTime Creacion { get; private set; }
        public ModoPagoCredito ModoPago { get; private set; }
        public EstadoCredito Estado { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public int CantidadCuotas { get; private set; }
        public ICollection<CuotaCredito> Cuotas { get; private set; } = new List<CuotaCredito>();

        protected Credito() { }
        public static Credito CrearSinCuotas(OpcionesCredito op)
        {
            var credito = new Credito();

            credito.Codigo = Guid.NewGuid().ToString();
            credito.DniEmpleado = op.Dni;
            credito.MontoPrestado = op.MontoPrestar;
            credito.MontoDevolver = op.MontoDevolver;
            credito.Descripcion = op.Descripcion;
            credito.Creacion = DateTime.Now;
            credito.Estado = EstadoCredito.SOLICITADO;
            credito.ModoPago = op.ModoPago;
            credito.CantidadCuotas = op.CantidadCuotas;
            credito.Cuotas = new List<CuotaCredito>();

            return credito;
        }

        public ICollection<CuotaCredito> GetCuotasSinPagar()
            => Cuotas
               .Where(c => c.Estado == CuotaCredito.EstadoCuota.PENDIENTE)
               .ToList();

        public void PagarCuota(int nro)
        {
            if(SeTerminoDePagar())
            {
                this.Estado = EstadoCredito.COMPLETADO;
                return;
            }

            this.Estado = EstadoCredito.PENDIENTE;
            var cuota = Cuotas.First(c => c.Nro == nro);

            if (cuota is not null)
            {
                cuota.Pagar();
            }
        }

        public ItemLiquidacion Acreditar(Liquidacion liquidacion)
        {
            CodigoLiquidacionAcreditacion = liquidacion.Codigo;
            Estado = EstadoCredito.PENDIENTE;

            return ItemLiquidacion.CrearRemunerativoEnNegro(Descripcion, MontoPrestado);
        }

        public void Desacreditar()
        {
            CodigoLiquidacionAcreditacion = null;
            Estado = EstadoCredito.SOLICITADO;
        }

        private bool SeTerminoDePagar()
        {
            return (Cuotas.All(c => c.Estado == CuotaCredito.EstadoCuota.PAGADA) && Cuotas.Any());
        }

        public decimal GetMondoPagado()
        => Cuotas.Where(c => c.Estado == CuotaCredito.EstadoCuota.PAGADA)
                 .Sum(c => c.Monto);

        public IEnumerable<CuotaCredito> GetCuotas() => Cuotas;


        public void AgregarCuota(CuotaCredito cuota)
        {
            if (cuota.CodigoCredito != Codigo)
            {
                throw new InvalidDataException("error.codigo.credito");
            }

            Cuotas.Add(cuota);
        }

        public void AgregarCuotas(IReadOnlyCollection<CuotaCredito> cuotas)
        {
            if(Cuotas.Count != 0)
                return;

                foreach (var cuota in cuotas)
                {
                cuota.AsignarCredito(this);
                    Cuotas.Add(cuota);
                }
        
        }

         public void PosponerAPartirDeLaCuota(int nroCuota)
        {
            var cuotasSinPagar = this.GetCuotasSinPagar();

            var cuotasAPatear = cuotasSinPagar.Where(c => c.Nro >= nroCuota).
                                            ToList();

            if (ModoPago == ModoPagoCredito.AMBAS_QUINCENAS)
            {
                foreach (var cuota in cuotasAPatear)
                {
                    cuota.PosponerUnaQuincena();
                }

                return;
            }


            foreach (var cuota in cuotasAPatear)
            {
                cuota.PosponerUnMes();
            }
        }

        public void ReemplazarCuotasPendientes(IEnumerable<CuotaCredito> nuevas)
        {
            var aQuitar = GetCuotasSinPagar().ToList();

            foreach (var c in aQuitar) Cuotas.Remove(c);

            foreach (var c in nuevas)
            {
                c.AsignarCredito(this);
                Cuotas.Add(c);
            }
        }

    }
}
