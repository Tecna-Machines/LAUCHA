using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
     public class Cuenta
    {
        string NumeroCuenta { get; set; } = null!;
        bool estadoCuenta { get; set; }
        DateTime FechaCreacion { get; set; }
        string DniEmpleado { get; set; } = null!;
    }
}
