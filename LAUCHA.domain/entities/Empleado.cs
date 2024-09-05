using LAUCHA.domain.entities.diasEspeciales;

namespace LAUCHA.domain.entities
{
    public class Empleado
    {
        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Cuenta Cuenta { get; set; } = null!;
        public ICollection<Contrato> Contratos { get; set; } = null!;
        public ICollection<AvisosAusencia> Ausencias { get; set; } = null!;
        public ICollection<HabilitacionHorasExtra> HabilitacionesHorasExtra { get; set; } = null!;
        public ICollection<PeriodoVacaciones> PeriodosVacaciones { get; set; } = null!;
    }

}
