namespace LAUCHA.domain.entities
{
    public class Credito
    {
        public string CodigoCredito { get; set; } = null!;
        public decimal Monto { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool SePagaQuincenal { get; set; }
        public bool Suspendido { get; set; }
        public string Descripcion { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
        public Cuenta Cuenta { get; set; } = null!;
        public int CantidadCuotasOriginales { get; set; }
        public int CantidadCuotasPagadas { get; set; }
        public int CantidadCuotasFaltantes { get; set; }
        public int NumeroConcepto { get; set; }
        public Concepto Concepto { get; set; } = null!;
        public ICollection<PagoCredito> PagosCreditos { get; set; } = null!;

        public decimal MontoCuota()
        {
            if(CantidadCuotasFaltantes == 0)
            {
                return (Monto - MontoPagado);
            }

            return (Monto - MontoPagado) / CantidadCuotasFaltantes;
        }
        public decimal montoFaltante()
        {
            return (Monto - MontoPagado);
        }
        public void cobrarProximaCuotaManual(decimal monto)
        {
            if (CantidadCuotasFaltantes == 0) { throw new IndexOutOfRangeException(); }
            Suspendido = true;
            MontoPagado = MontoPagado + monto;
            CantidadCuotasFaltantes = CantidadCuotasFaltantes - 1;
            CantidadCuotasPagadas = CantidadCuotasPagadas + 1;
        }
        public void CobrarProximaCuota()
        {
            if (CantidadCuotasFaltantes == 0) { throw new IndexOutOfRangeException(); }
            MontoPagado = MontoPagado + MontoCuota();
            CantidadCuotasFaltantes = CantidadCuotasFaltantes - 1;
            CantidadCuotasPagadas = CantidadCuotasPagadas + 1;
        }
    }
}
