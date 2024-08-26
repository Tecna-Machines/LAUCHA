namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class PagoCreditoDTO
    {
        public DateTime FechaPago { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
    }
}
