namespace LAUCHA.domain.Entities.Creditos
{
    public class Credito
    {
        public string Codigo { get; set; } = null!;
        public decimal MontoPrestado { get; set; }
        public decimal MontoDevolver { get; set; }
        public string DniEmpleado { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Creacion { get; set; }
        public ModoPagoCredito ModoPago { get; set; }
        public EstadoCredito Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public int CantidadCuotas { get; set; }
        public ICollection<CuotaCredito> Cuotas { get; set; } = null!;

        public static Credito CrearSinCuotas(OpcionesCredito op)
        {
            var credito = new Credito();

            credito.Codigo = new Guid().ToString();
            credito.DniEmpleado = op.Dni;
            credito.MontoPrestado = op.MontoPrestar;
            credito.MontoDevolver = op.MontoDevolver;
            credito.Descripcion = op.Descripcion;
            credito.Creacion = DateTime.Now;
            credito.Estado = EstadoCredito.INCOMPLETO;
            credito.CantidadCuotas = op.CantidadCuotas;
            credito.Cuotas = new List<CuotaCredito>();

            return credito;
        }
        public void PagarCuota(int nro)
        {
            var cuota = Cuotas.First(c => c.Nro == nro);

            if (cuota is not null)
            {
                cuota.Pagar();
            }
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


    }
}
