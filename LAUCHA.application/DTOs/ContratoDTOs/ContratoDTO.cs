using LAUCHA.application.DTOs.AcuerdoBlancoDTOs;
using LAUCHA.application.DTOs.AdicionalDTOs;
using LAUCHA.application.DTOs.ModalidadDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.DTOs.ContratoDTO
{
    public class ContratoDTO
    {
        public string Codigo { get; set; } = null!;
        public string Dni { get;set; } = null!;
        public string Empleado { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public decimal MontoHora { get; set; }
        public decimal MontoFijo { get; set; }
        public string Tipo { get; set; } = null!;
        public AcuerdoBlancoDTO AcuerdoBlanco { get; set; } = null!;
        public ModalidadDTO Modalidad { get; set; } = null!;
        public List<AdicionalDTO>? Adicionales { get; set; } 

    }
}
