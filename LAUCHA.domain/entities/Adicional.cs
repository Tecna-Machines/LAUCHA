﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Adicional
    {
        public string CodigoAdicional { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
        public IList<AdicionalPorContrato> AdicionalesPorContrato { get; set; } = null!;
    }
}
