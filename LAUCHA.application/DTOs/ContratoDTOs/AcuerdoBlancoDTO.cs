using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.ContratoDTO
{
    public class AcuerdoBlancoDTO
    {
        public decimal Cantidad;
        public string Concepto { get; set; } = null!;
        public bool EsPorcentual { get; set; }
    }
}
