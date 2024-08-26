namespace LAUCHA.application.DTOs.RetencionDTOs
{
    public class CrearRetencionDTO
    {
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public string NumeroCuenta { get; set; } = null!;
    }
}
