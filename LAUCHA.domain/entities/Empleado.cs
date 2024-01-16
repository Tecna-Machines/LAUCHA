using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
     public class Empleado
    {
        string Dni { get; set; } = null!;
        string Nombre { get; set; } = null!;
        string Apellido { get; set; } = null!;
        DateTime FechaNacimiento { get; set; }
        DateTime FechaIngreso { get; set; }
    }

}
