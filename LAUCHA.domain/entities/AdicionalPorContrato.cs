using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class AdicionalPorContrato
    {
        public string CodigoAdicional { get; set; } = null!;
        public Adicional Adicional { get; set; } = null!;
        public string CodigoContrato { get; set; } = null!;
        public Contrato Contrato { get; set; } = null!;
    }
}
