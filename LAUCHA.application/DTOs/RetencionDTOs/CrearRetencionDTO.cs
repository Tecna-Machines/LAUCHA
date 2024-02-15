using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.RetencionDTOs
{
    public class CrearRetencionDTO
    {
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public string NumeroCuenta { get; set; } = null!;
    }
}
