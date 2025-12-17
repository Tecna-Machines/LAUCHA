using LAUCHA.domain.Entities.Creditos;
using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.domain.entities
{
    public class Cuenta
    {
        public string NumeroCuenta { get; set; } = null!;
        public bool EstadoCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string DniEmpleado { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;
        public ICollection<Credito> Creditos { get; set; } = null!;
        public ICollection<Descuento> Descuentos { get; set; } = null!;
        public ICollection<RetencionOLD> Retenciones { get; set; } = null!;
        public ICollection<NoRemuneracion> NoRemuneraciones { get; set; } = null!;
        public ICollection<Remuneracion> Remuneraciones { get; set; } = null!;

        public Cuenta() { }
        public Cuenta(Empleado empleado)
        {
            NumeroCuenta = $"{empleado.Dni}:00";
            DniEmpleado = empleado.Dni;
            EstadoCuenta = true;
            FechaCreacion = DateTime.Now;
        }
    }
}
