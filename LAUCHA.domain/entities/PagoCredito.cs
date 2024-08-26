namespace LAUCHA.domain.entities
{
    public class PagoCredito
    {
        public string CodigoDescuento { get; set; } = null!;
        public Descuento Descuento { get; set; } = null!;
        public string CodigoCredito { get; set; } = null!;
        public Credito Credito { get; set; } = null!;
        public DateTime FechaPago { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }

    }
}
