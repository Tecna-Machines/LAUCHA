using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.ContratoDTOs
{
    public class ResumenContratoDTO
    {
        public string Codigo { get; set; } = null!;
        public decimal MontoHora { get; set; }
        public decimal MontoFijo { get; set; }
        public string Fecha { get; set; } = null!;
    }
}
