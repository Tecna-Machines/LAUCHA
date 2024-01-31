using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Contrato
    {
        public string CodigoContrato { get; set; } = null!;
        public string TipoContrato { get; set; } = null!;
        public decimal MontoPorHora { get; set; }
        public decimal MontoFijo { get; set; }
        public decimal FechaContrato {  get; set; }
        public string DniEmpleado { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;
    }
}
