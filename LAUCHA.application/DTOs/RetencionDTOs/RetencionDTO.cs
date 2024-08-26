namespace LAUCHA.application.DTOs.RetencionDTOs
{
    public class RetencionDTO : CrearRetencionDTO
    {
        public string Codigo { get; set; } = null!;
        public DateTime Fecha { get; set; }
    }
}
