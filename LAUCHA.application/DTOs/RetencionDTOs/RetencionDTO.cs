using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.RetencionDTOs
{
    public class RetencionDTO : CrearRetencionDTO
    {
        public string Codigo { get; set; } = null!;
        public DateTime Fecha { get; set; }
    }
}
