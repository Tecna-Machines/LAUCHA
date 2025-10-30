using LAUCHA.domain.entities.Contrato;

namespace LAUCHA.domain.Entities.Acuerdos
{
    public class Acuerdo
    {
        public string Codigo { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal ValorHora { get; set; }

        /// <summary>
        /// indica la parte legal del empleado , si es mensual sera un monto fijo
        /// si es jornal indicara el valor por hora
        /// </summary>
        public decimal ValorBlanco { get; set; }
        public decimal Sueldo { get; set; }
        public string? Notas { get; set; }
        public string DniEmpleado { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;
        public TipoSueldo TipoSueldo { get; set; }
        public ICollection<Adicional> Adicionales { get; set; } = null!;
    }
}
