namespace LAUCHA.domain.entities.diasEspeciales
{
    public class HabilitacionHorasExtra
    {
        public string DniEmpleado { get; set; } = null!;
        public string DniResponsable { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public Empleado Empleado { get; set; } = null!;
        public Empleado Responsable { get; set; } = null!;
    }
}
