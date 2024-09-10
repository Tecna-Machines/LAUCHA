using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo1
{
    public class ModuloRecuperadorEmpleado : IModuloLiquidador
    {
        private readonly IConsultarEmpleadoService _empleadoService;
        private readonly IAgregarCuentaService _cuentaService;
        private readonly IMarcasService _marcasService;
        private readonly IConsultarContratoTrabajoService _contratoService;
        public ModuloRecuperadorEmpleado(IConsultarEmpleadoService empleadoService,
                                         IAgregarCuentaService cuentaService,
                                         IMarcasService marcasService,
                                         IConsultarContratoTrabajoService contratoService)
        {
            _empleadoService = empleadoService;
            _cuentaService = cuentaService;
            _marcasService = marcasService;
            _contratoService = contratoService;
        }

        public void EjecutarRutina(LiquidacionPayload payload)
        {
            payload.Empleado = this.obtenerDatosEmpleado(payload.dniEmpleado);
            payload.Cuenta = this.obtenerDatosCuenta(payload.Empleado.NumeroCuenta);
            payload.marcasDelPeriodo = this.obtenerMarcasDelPeriodo(payload.dniEmpleado, payload.periodoliquidar);
            payload.Contrato = this.obtenerContratoEmpleado(payload.dniEmpleado);

            payload.RetencionesFijasCuenta = payload.Cuenta.Retenciones;

        }

        private EmpleadoDTO obtenerDatosEmpleado(string dniEmpleado)
        {
            return _empleadoService.ConsultarUnEmpleado(dniEmpleado);
        }

        private CuentaDTO obtenerDatosCuenta(string numeroCuenta)
        {
            return _cuentaService.ConsularUnaCuenta(numeroCuenta);
        }

        private List<MarcaVista> obtenerMarcasDelPeriodo(string dni, PeriodoDTO periodo)
        {
            return _marcasService.ConsultarMarcasPeriodoVista(dni, periodo.Inicio, periodo.Fin);
        }

        private ContratoDTO obtenerContratoEmpleado(string dni)
        {
            return _contratoService.ObtenerContratoDeEmpleado(dni);
        }
    }
}
