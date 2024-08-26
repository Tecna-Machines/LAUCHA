namespace LAUCHA.application.DTOs.CreditoDTOs
{
    public class CrearCreditoDTO
    {
        public decimal Monto { get; set; }
        public DateTime FechaInicioPago { get; set; }
        public string Descripcion { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
        public int CantidadCuotas { get; set; }
        public int NumeroConcepto { get; set; }
        public bool esQuincenal { get; set; }
    }
}
