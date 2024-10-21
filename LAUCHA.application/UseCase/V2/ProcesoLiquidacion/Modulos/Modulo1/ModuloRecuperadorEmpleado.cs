using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.Enums;
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

        public Task EjecutarRutina(LiquidacionPayload payload)
        {
            payload.Empleado = this.obtenerDatosEmpleado(payload.dniEmpleado);
            payload.Cuenta = this.obtenerDatosCuenta(payload.Empleado.NumeroCuenta);
            payload.Contrato = this.obtenerContratoEmpleado(payload.dniEmpleado);
            payload.marcasDelPeriodo = this.obtenerMarcasDelPeriodo(payload.Contrato.Modalidad.Codigo, payload.dniEmpleado, payload.periodoliquidar);

            payload.RetencionesFijasCuenta = payload.Cuenta.Retenciones;

            return Task.CompletedTask;
        }

        private EmpleadoDTO obtenerDatosEmpleado(string dniEmpleado)
        {
            return _empleadoService.ConsultarUnEmpleado(dniEmpleado);
        }

        private CuentaDTO obtenerDatosCuenta(string numeroCuenta)
        {
            return _cuentaService.ConsularUnaCuenta(numeroCuenta);
        }

        private List<MarcaVista> obtenerMarcasDelPeriodo(string codigoModalidad,string dni, PeriodoDTO periodo)
        {
            DateTime fechaInicio = periodo.Inicio;

            int modalidad;
            bool parseCodigo = int.TryParse(codigoModalidad, out modalidad);


            if(modalidad == (int)ModalidadContrato.mensualFijo || modalidad == (int)ModalidadContrato.mensualFijoHorasExtra)
            {
                fechaInicio = new DateTime(periodo.Inicio.Year, periodo.Inicio.Month, 1);
            }

            return _marcasService.ConsultarMarcasPeriodoVista(dni,fechaInicio, periodo.Fin);
        }

        private ContratoDTO obtenerContratoEmpleado(string dni)
        {
            return _contratoService.ObtenerContratoDeEmpleado(dni);
        }

    }
}
