namespace LAUCHA.application.DTOs.RetencionesFijasDTOs
{
    public class RetencionFijaConHistorialDTO : RetencionFijaDTO
    {
        public List<HistorialRetencionDTO> Historial { get; set; } = null!;
    }

    public class HistorialRetencionDTO
    {
        public DateTime FechaFinVigencia { get; set; }
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
    }

}
