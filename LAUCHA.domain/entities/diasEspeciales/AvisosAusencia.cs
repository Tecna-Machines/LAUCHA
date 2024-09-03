namespace LAUCHA.domain.entities.diasEspeciales
{
    public class AvisosAusencia
    {
        public string DniEmpleado { get; set; } = null!;
        public DateTime FechaAusencia { get; set; }
        public string Motivo { get; set; } = null!;
        public DateTime FechaCreacionAviso { get; set; }
        public Empleado Empleado { get; set; } = null!;
    }
}
