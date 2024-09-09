using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.domain.entities;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models
{
    public class LiquidacionPayload
    {
        public PeriodoDTO periodoliquidar { get; set; } = null!;
        public string dniEmpleado { get; set; } = null!;
        public bool esSimulacion { get; set; }
        public ContratoDTO Contrato { get; set; } = null!;
        public CuentaDTO Cuenta { get; set; } = null!;
        public EmpleadoDTO Empleado { get; set; } = null!;

        public int totalMontoRemunerativo;
        public int totalMontoNoRemunerativo;
        public int totalMontoDescuento;
        public int totalMontoRetenciones;

        public List<Remuneracion> remuneracionesLiquidacion { get; set; } = null!;
        public List<NoRemuneracion> noRemuneracionesLiquidacion { get; set; } = null!;
        public List<Descuento> descuentosLiquidacion { get; set; } = null!;
        public List<Retencion> retencionesLiquidacion { get; set; } = null!;

    }
}
