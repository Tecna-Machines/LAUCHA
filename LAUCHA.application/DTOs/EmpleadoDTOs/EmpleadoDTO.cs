namespace LAUCHA.application.DTOs.EmpleadoDTO
{
    public class EmpleadoDTO : CrearEmpleadoDTO
    {
        public string NumeroCuenta { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public bool EstadoCuenta { get; set; }
        public ContratoResumenDTO ContratoResumen { get; set; } = null!;
    }

    public class ContratoResumenDTO
    {
        public string CodigoContrato { get; set; } = null!;
        public string CodigoModalidad { get; set; } = null!;
        public string DescripcionModalidad { get; set; } = null!;
    }
}
