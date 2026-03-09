using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.domain.Entities.Asistencias
{
    public class FaltaJustificada
    {
        public string DniEmpleado { get; private set; } = string.Empty;
        public DateTime FechaJustificada { get; private set; }
        public string Motivo { get; private set; } = string.Empty;
        public DateTime FechaCarga { get; private set; }

        public static FaltaJustificada Crear(Empleado emp, DateTime fechaJustificada, string motivo)
        {
            return new FaltaJustificada
            {
                DniEmpleado = emp.Dni,
                FechaJustificada = fechaJustificada,
                Motivo = motivo,
                FechaCarga = DateTime.Now
            };
        }
    }

}
