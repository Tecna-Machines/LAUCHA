namespace LAUCHA.domain.entities.diasEspeciales
{
    public class PeriodoVacaciones
    {
        public string DniEmpleado { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observacion { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;
    }
}
