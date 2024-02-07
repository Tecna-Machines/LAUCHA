using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class ModalidadPorContrato
    {
        public string CodigoContrato { get; set; } = null!;
        public Contrato Contrato { get; set; } = null!;
        public string CodigoModalidad { get; set; } = null!;
        public Modalidad Modalidad { get; set; } = null!;
    }
}
