namespace LAUCHA.domain.interfaces.IServices
{
    public class CostoPersonalResponse
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public DateTime InicioPeriodo { get; set; }
        public DateTime FinPeriodo { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal Descuento { get; set; }
        public int CantidadPedidos { get; set; }
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
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Token { get; set; }
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
