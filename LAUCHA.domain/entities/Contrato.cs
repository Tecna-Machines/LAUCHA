using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Contrato
    {
        string CodigoContrato { get; set; } = null!;
        string TipoContrato { get; set; } = null!;
        Decimal MontoPorHora { get; set; }
        string Modalidad { get; set; } = null!;
        DateTime FechaContrato {  get; set; }
        string DniEmpleado { get; set; } = null!;
    }
}
