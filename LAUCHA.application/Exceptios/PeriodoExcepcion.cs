namespace LAUCHA.application.Exceptios
{
    public class PeriodoExcepcion : Exception
    {
        public PeriodoExcepcion(string mensaje) : base(mensaje)
        {
            Codigo = 400;
        }

        public int Codigo { get; set; }
    }
}
