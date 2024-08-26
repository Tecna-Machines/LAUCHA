﻿namespace LAUCHA.domain.entities
{
    public class Retencion
    {
        public string CodigoRetencion { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public Cuenta Cuenta { get; set; } = null!;
        public IList<RetencionPorLiquidacionPersonal> RetencionPorLiquidacionPersonales { get; set; } = null!;
    }
}
