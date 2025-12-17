namespace LAUCHA.domain.Entities.Creditos
{
    public class CuotaCredito
    {
        public int Nro { get; set; }
        public string CodigoCredito { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime FechaPago { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public enum EstadoCuota
        {
            PAGADA,
            PENDIENTE
        }

        public EstadoCuota Estado { get; set; }

        public int QuincenaDebitar { get; set; }
        public int MesDebitar { get; set; }
        public int AnioDebitar { get; set; }

        //referencia a que item de que liquidacion se asocia esta cuota
        public int NroItem { get; set; }
        public string CodigoLiquidacion { get; set; } = string.Empty;

        public void Pagar()
        {
            Estado = EstadoCuota.PAGADA;
            FechaPago = DateTime.Now;
        }
    }
}
