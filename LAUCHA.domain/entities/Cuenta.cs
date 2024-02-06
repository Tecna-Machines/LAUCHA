using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
     public class Cuenta
    {
        public string NumeroCuenta { get; set; } = null!;
        public bool estadoCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string DniEmpleado { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;
        public ICollection<Credito> Creditos { get; set; } = null!;
        public IList<RetencionFijaPorCuenta> RetencionesFijasPorCuenta { get; set; } = null!;
        public ICollection<Descuento> Descuentos { get; set; } = null!;
        public ICollection<Retencion> Retenciones {  get; set; } = null!;
        public ICollection<Remuneracion> Remuneraciones { get; set; } = null!;

    }
}
