namespace LAUCHA.application.DTOs.RemuneracionDTOs
{
    public class CrearRemuneracionDTO
    {
        public string Cuenta { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public bool EsBlanco { get; set; }
    }
}
