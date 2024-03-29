﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class Cuota
    {
        public string CodigoCuota { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime FechaDebePagar { get; set; }
        public string CodigoCredito { get; set; } = null!;
        public Credito Credito { get; set; } = null!;
        public ICollection<Subcuota> Subcuotas { get; set; } = null!;
        public IList<CuotaPorLiquidacionPersonal> CuotasPorLiquidaciones { get; set; } = null!;
    }
}
