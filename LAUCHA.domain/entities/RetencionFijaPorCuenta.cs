﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class RetencionFijaPorCuenta
    {
        public string NumeroCuenta { get; set; } = null!;
        public Cuenta Cuenta { get; set; } = null!;
        public string CodigoRetencionFija { get; set; } = null!;
        public RetencionFija RetencionFija { get; set; } = null!;
    }
}
