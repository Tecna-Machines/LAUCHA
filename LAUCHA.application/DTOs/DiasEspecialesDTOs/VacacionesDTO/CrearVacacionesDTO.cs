namespace LAUCHA.application.DTOs.DiasEspecialesDTOs.VacacionesDTO
{
    public class CrearVacacionesDTO
    {
        public string DniEmpleado { get; set; } = null!;
        public DateTime InicioVacaciones { get; set; }
        public DateTime FinVacaciones { get; set; }
        public string? Observacion { get; set; }
    }
}
