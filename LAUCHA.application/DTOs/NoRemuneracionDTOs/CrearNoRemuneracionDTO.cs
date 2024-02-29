namespace LAUCHA.application.DTOs.NoRemuneracionDTOs
{
    public class CrearNoRemuneracionDTO
    {
        public string Cuenta { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
    }
}
