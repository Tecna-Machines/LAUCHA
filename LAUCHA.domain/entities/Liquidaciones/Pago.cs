namespace LAUCHA.domain.Entities.Liquidaciones
{
    public class Pago
    {
        public string Id { private set; get; }
        public string LiquidacionId { private set; get; }
        public string Descripcion { private set; get; }
        public DateTime Fecha { private set; get; }
        public decimal Monto { private set; get; }
        public enum ModoPago
        {
            EFECTIVO,
            TRANSFERENCIA
        }
        public ModoPago Modo { private set; get; }

        public Pago(string liquidacionId, string descripcion)
        {
            Id = new Guid().ToString();
            LiquidacionId = liquidacionId;
            Descripcion = descripcion;
            Fecha = DateTime.Now;
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

    }
}
