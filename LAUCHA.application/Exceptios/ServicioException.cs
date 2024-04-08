namespace LAUCHA.application.Exceptios
{
    public class ServicioException : Exception
    {
        public ServicioException(string mensaje, string serviceName) : base(mensaje)
        {
            ServiceName = serviceName;
        }

        public string ServiceName { get; }
    }
}
