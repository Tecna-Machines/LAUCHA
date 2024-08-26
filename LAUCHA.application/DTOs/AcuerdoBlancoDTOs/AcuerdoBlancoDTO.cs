namespace LAUCHA.application.DTOs.AcuerdoBlancoDTOs
{
    public class AcuerdoBlancoDTO
    {
        public string Concepto { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public bool EsPorcentual { get; set; }
    }
}
