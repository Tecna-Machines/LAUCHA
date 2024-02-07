using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.EmpleadoDTO
{
    public class CrearEmpleadoDTO
    {
        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaNacimiento { get;set; }
    }
}
