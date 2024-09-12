using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models
{
    public class LiquidacionPayload
    {
        //TODO: eliminar
        public string CodigoLiquidacion { get; set; } = null!;

        public PeriodoDTO periodoliquidar { get; set; } = null!;
        public string dniEmpleado { get; set; } = null!;
        public bool esSimulacion { get; set; }
        public ContratoDTO Contrato { get; set; } = null!;
        public CuentaDTO Cuenta { get; set; } = null!;
        public List<RetencionFijaDTO> RetencionesFijasCuenta { get; set; } = null!;
        public EmpleadoDTO Empleado { get; set; } = null!;

        private LiquidacionDTO? Resultado;

        private decimal totalMontoRemunerativo;
        private decimal totalMontoNoRemunerativo;
        private decimal totalMontoDescuento;
        private decimal totalMontoRetenciones;

        public List<MarcaVista> marcasDelPeriodo { get; set; } = null!;

        public List<Remuneracion> remuneracionesLiquidacion { get; set; } = null!;
        public List<NoRemuneracion> noRemuneracionesLiquidacion { get; set; } = null!;
        public List<Descuento> descuentosLiquidacion { get; set; } = null!;
        public List<Retencion> retencionesLiquidacion { get; set; } = null!;

        private IEstrategiaCalcularSueldo? CalculadoraSueldo { get; set; }

        public IEstrategiaCalcularSueldo? GetCalculadoraSueldo() => CalculadoraSueldo;
        public IEstrategiaCalcularSueldo SetCalculadoraSueldo(IEstrategiaCalcularSueldo calcu)
        {
            CalculadoraSueldo = calcu;
            return this.CalculadoraSueldo;
        }

        public void actualizarMontos()
        {
            totalMontoRemunerativo = (this.remuneracionesLiquidacion?.Where(r => r.EsBlanco == true).Sum(r => r.Monto)) ?? 0;
            totalMontoNoRemunerativo = (this.noRemuneracionesLiquidacion?.Sum(r => r.Monto)) ?? 0;
            totalMontoRetenciones = (this.retencionesLiquidacion?.Sum(r => r.Monto)) ?? 0;
            totalMontoDescuento = (this.descuentosLiquidacion?.Sum(d => d.Monto)) ?? 0;
        }


        public decimal GetMontoRemunerativo() => this.totalMontoRemunerativo;
        public decimal GetMontoNoRemunerativo() => this.totalMontoNoRemunerativo;
        public decimal GetMontoDescuentos() => this.totalMontoDescuento;
        public decimal GetMontoRetenciones() => this.totalMontoRetenciones;

        public void Inicializar(string dniEmp, PeriodoDTO periodo, bool esSimulacion)
        {
            this.dniEmpleado = dniEmp;
            this.periodoliquidar = periodo;
            this.esSimulacion = esSimulacion;

            this.remuneracionesLiquidacion = new List<Remuneracion>();
            this.noRemuneracionesLiquidacion = new List<NoRemuneracion>();
            this.descuentosLiquidacion = new List<Descuento>();
            this.retencionesLiquidacion = new List<Retencion>();
        }

        public LiquidacionDTO? ObtenerResultado()
        {
            return this.Resultado;
        }

        public void SetResultado(LiquidacionDTO liquidacionGenerada)
        {
            this.Resultado = liquidacionGenerada;
        }

    }
}
