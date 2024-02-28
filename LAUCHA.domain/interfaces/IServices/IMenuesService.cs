namespace LAUCHA.domain.interfaces.IServices
{
    public class CostoPersonalResponse
    {
        public Guid id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? dni { get; set; }
        public DateTime inicioPeriodo { get; set; }
        public DateTime finPeriodo { get; set; }
        public decimal costoTotal { get; set; }
        public decimal descuento { get; set; }
        public int cantidadPedidos { get; set; }
    }

    public class PersonalResponse
    {
        public Guid id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }

        public string? dni { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_ingreso { get; set; }

        public string? mail { get; set; }
        public string? telefono { get; set; }
        public bool isAutomatico { get; set; }
    }

    public class UsuarioLoginResponse
    {
        public Guid id { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? token { get; set; }
    }

    public class UsuarioLoginRequest
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }

    public interface IMenuesService
    {
        Task<CostoPersonalResponse> ObtenerGastosComida(string dniEmpleado, DateTime inicioPeriodo, DateTime finPeriodo);
    }
}
