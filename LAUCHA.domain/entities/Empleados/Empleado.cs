using LAUCHA.domain.entities;
using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.domain.Entities.Empleados
{
    public class Empleado
    {
        public string Dni { get; set; } = null!;
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
        public Cuenta Cuenta { get; set; } = null!;
        public ICollection<Acuerdo> Contratos { get; set; } = null!;
        public ICollection<AvisosAusencia> Ausencias { get; set; } = null!;
        public ICollection<HabilitacionHorasExtra> HabilitacionesHorasExtra { get; set; } = null!;
        public ICollection<PeriodoVacaciones> PeriodosVacaciones { get; set; } = null!;

    }

}
