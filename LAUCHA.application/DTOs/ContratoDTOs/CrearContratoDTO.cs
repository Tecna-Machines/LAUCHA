using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;

namespace LAUCHA.application.DTOs.ContratoDTOs
{
    public class CrearContratoDTO
    {
        public string Dni { get; set; } = null!;
        public decimal MontoHora { get; set; }
        public decimal MontoFijo { get; set; }
        public string Modalidad { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string[] Adicionales { get; set; } = null!;
        public AcuerdoBlancoDTO AcuerdoBlanco { get; set; } = null!;
    }
}
