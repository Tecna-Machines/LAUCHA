namespace LAUCHA.domain.Entities.Liquidaciones
{
    public class Pago
    {
        public string Id { private set; get; }
        public string LiquidacionId { private set; get; }
        public string Descripcion { private set; get; }
        public DateTime Fecha { private set; get; }
        public decimal Monto { private set; get; }
        public string? ReferenciaContabilidad { private set; get; }
        public EstadoContabilidad EstadoContable { private set; get; }
        public enum EstadoContabilidad
        {
            PENDIENTE,
            ERROR,
            ENVIADO
        }
        public enum ModoPago
        {
            EFECTIVO,
            TRANSFERENCIA
        }
        public ModoPago Modo { private set; get; }

        public Pago(string liquidacionId,
                    string descripcion,
                    ModoPago modo,
                    decimal monto)
        {
            Id = Guid.NewGuid().ToString("N");
            LiquidacionId = liquidacionId;
            Descripcion = descripcion;
            Fecha = DateTime.Now;
            Modo = modo;
            EstadoContable = EstadoContabilidad.PENDIENTE;

            SetMonto(monto);
        }

        public void AbonarEnEfectivo(decimal monto)
        {
            SetMonto(monto);

            Modo = ModoPago.EFECTIVO;
        }

        public void AbonarEnTransferencia(decimal monto)
        {
            SetMonto(monto);
            Modo = ModoPago.TRANSFERENCIA;
        }

        private void SetMonto(decimal monto)
        {
            if (monto < 0)
                throw new Exception("monto.negativo");

            Monto = monto;
        }

        public void MarcarComoEnviado(string referenciaContabilidad)
        {
            this.ReferenciaContabilidad = referenciaContabilidad;
            EstadoContable = EstadoContabilidad.ENVIADO;
        }

    }
}
