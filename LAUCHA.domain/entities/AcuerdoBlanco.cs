﻿namespace LAUCHA.domain.entities
{
    public class AcuerdoBlanco
    {
        public string CodigoAcuerdoBlanco { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
        public string CodigoContrato { get; set; } = null!;
        public Contrato Contrato { get; set; } = null!;
    }
}
