namespace LAUCHA.application.Exceptios
{
    public class SueldoException : Exception
    {
        public SueldoException(string mensaje) : base(mensaje)
        {
            Codigo = 400;
        }

        public int Codigo { get; set; }

    }
}
