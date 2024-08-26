namespace LAUCHA.domain.entities
{
    public class Concepto
    {
        public int NumeroConcepto { get; set; }
        public string NombreConcepto { get; set; } = null!;
        public ICollection<Descuento> Descuentos { get; set; } = null!;
        public ICollection<Credito> Creditos { get; set; } = null!;
    }
}
