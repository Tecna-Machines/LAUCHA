using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.RemuneracionDTOs
{
    public class RemuneracionDTO : CrearRemuneracionDTO
    {
        public string Codigo { get; set; } = null!;
        public string Fecha { get; set; } = null!;
    }
}
