namespace LAUCHA.application.DTOs.DiasEspecialesDTOs.HabilitacionHsExtraDTO
{
    public class CrearHabilitacionHsExtraDTO
    {
        public string DniEmpleado { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string DniResponsable { get; set; } = null!;
    }

}
