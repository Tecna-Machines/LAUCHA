namespace LAUCHA.application.DTOs.DiasEspecialesDTOs.AusenciasDTO
{
    public class CrearAusenciaDTO
    {
        public string DniEmpleado { get; set; } = null!;
        public DateTime FechaAusencia { get; set; }
        public string Motivo { get; set; } = null!;
    }
}
