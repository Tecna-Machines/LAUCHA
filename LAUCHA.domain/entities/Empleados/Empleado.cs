using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.domain.Entities.Empleados
{
    public class Empleado
    {
        public string Dni { get; set; } = null!;
        public string Cuil { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// ingreso del empleado , se utiliza para calcular antiguedad
        /// </summary>
        public DateTime FechaIngreso { get; set; }

        /// <summary>
        /// fecha de alta legal del empleado
        /// </summary>
        public DateTime FechaAlta { get; set; }
        public ICollection<Acuerdo> Contratos { get; set; } = null!;


        public int GetAntiguedad()
        {
            var hoy = DateTime.Today;

            int anios = hoy.Year - FechaIngreso.Year;

            if (hoy.Month < FechaIngreso.Month ||
                (hoy.Month == FechaIngreso.Month && hoy.Day < FechaIngreso.Day))
            {
                anios--;
            }

            return Math.Max(anios, 0);
        }

        public string GetFullName() => $"{Nombre} {Apellido}";

    }

}
