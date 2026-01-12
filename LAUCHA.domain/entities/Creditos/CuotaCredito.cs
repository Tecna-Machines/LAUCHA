namespace LAUCHA.domain.Entities.Creditos
{
    public class CuotaCredito
    {
        public int Nro { get; private set; }
        public string CodigoCredito { get;private set; } = string.Empty;
        public decimal Monto { get; private set; }
        public DateTime Creacion { get; private set; }
        public DateTime FechaPago { get; private set; }
        public string Descripcion { get; private set; } = string.Empty;

        public enum EstadoCuota
        {
            PAGADA,
            PENDIENTE
        }

        public EstadoCuota Estado { get; set; }

        public int QuincenaDebitar { get; set; }
        public int MesDebitar { get; set; }
        public int AnioDebitar { get; set; }

        //referencia a que item de que liquidacion se asocia esta cuota
        public int? NroItem { get; set; }
        public string? CodigoLiquidacion { get; set; } = string.Empty;

        public static CuotaCredito Crear(int nro,decimal monto)
        {
            var cuota =  new CuotaCredito();

            cuota.Nro = nro;
            cuota.Creacion = DateTime.Now;
            cuota.Estado = EstadoCuota.PENDIENTE;
            cuota.Monto = monto;

            return cuota;
        }

        public void AsignarCredito(Credito credito)
        {
            CodigoCredito = credito.Codigo;
        }

        public void SetQuincenaDebitar(int quincena,int mes,int anio)
        {
            QuincenaDebitar = quincena;
            MesDebitar = mes;
            AnioDebitar = anio;
        }

        public void SetDescripcion(string descripcion)
        {
            Descripcion = descripcion;
        }
        public void Pagar()
        {
            Estado = EstadoCuota.PAGADA;
            FechaPago = DateTime.Now;
        }

        public void AsociarConItemLiquidacion(string codigoLiquidacion,int nroItem)
        {
            this.CodigoLiquidacion = codigoLiquidacion;
            this.NroItem = nroItem;
        }

        public void PosponerUnMes()
        {
            if (MesDebitar == 12)
            {
                MesDebitar = 1;
                AnioDebitar++;
            }
            else
            {
                MesDebitar++;
            }
        }

        public void PosponerUnaQuincena()
        {
            if (QuincenaDebitar == 1)
            {
                QuincenaDebitar = 2;
            }
            else if (QuincenaDebitar == 2)
            {
                QuincenaDebitar = 1;
                PosponerUnMes();
            }
            else
            {
                throw new InvalidOperationException("QuincenaDebitar invalida");
            }
        }

    }
}
