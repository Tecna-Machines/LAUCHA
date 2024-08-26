using LAUCHA.application.DTOs.RetencionesFijasDTOs;

namespace LAUCHA.application.DTOs.CuentaDTOs
{
    public class CuentaDTO
    {
        public string NumeroCuenta { get; set; } = null!;
        public string Empleado { get; set; } = null!;
        public List<RetencionFijaDTO> Retenciones { get; set; } = null!;
    }
}
