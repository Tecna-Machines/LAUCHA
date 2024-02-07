using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.SystemaDTO
{
    public class RespuestaSystema
    {
        public string Mensaje { get; set; } = null!;
        public int StatusCode { get; set; }
    }
}
