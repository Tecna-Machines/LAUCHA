namespace LAUCHA.application.DTOs.ContratoDTOs
{
    public class ResumenContratoDTO
    {
        public string Codigo { get; set; } = null!;
        public decimal MontoHora { get; set; }
        public decimal MontoFijo { get; set; }
        public string Fecha { get; set; } = null!;
    }
}
