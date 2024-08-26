﻿namespace LAUCHA.domain.entities
{
    public class HistorialRetencionFija
    {
        public string CodigoRetencionFija { get; set; } = null!;
        public string Concepto { get; set; } = null!;
        public decimal Unidades { get; set; }
        public bool EsPorcentual { get; set; }
        public DateTime FechaFinVigencia { get; set; }
        public RetencionFija RetencionFija { get; set; } = null!;
    }
}
