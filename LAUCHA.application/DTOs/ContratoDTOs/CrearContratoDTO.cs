using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.ModalidadDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.ContratoDTO
{
    public class CrearContratoDTO
    {
        public string Dni { get; set; } = null!;
        public decimal MontoHora { get; set; }
        public decimal MontoFijo { get; set; }
        public string Modalidad { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string[] Adicionales { get; set; } = null!;
        public AcuerdoBlancoDTO AcuerdoBlanco { get; set; } = null!;
    }
}
