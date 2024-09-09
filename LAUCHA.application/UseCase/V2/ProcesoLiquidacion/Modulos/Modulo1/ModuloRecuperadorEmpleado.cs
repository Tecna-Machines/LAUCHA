using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo1
{
    public class ModuloRecuperadorEmpleado : IModuloLiquidador
    {
        private readonly IConsultarEmpleadoService _empleadoService;
        private readonly IAgregarCuentaService _cuentaService;

        public ModuloRecuperadorEmpleado(IConsultarEmpleadoService empleadoService, IAgregarCuentaService cuentaService)
        {
            _empleadoService = empleadoService;
            _cuentaService = cuentaService;
        }

        public void ejecutarRutina(LiquidacionPayload payload)
        {
            payload.Empleado = this.obtenerDatosEmpleado(payload.dniEmpleado);
            payload.Cuenta = this.obtenerDatosCuenta(payload.Empleado.NumeroCuenta);
            
        }

        private EmpleadoDTO obtenerDatosEmpleado(string dniEmpleado)
        {
            return _empleadoService.ConsultarUnEmpleado(dniEmpleado);
        }

        private CuentaDTO obtenerDatosCuenta(string numeroCuenta)
        {
           return _cuentaService.ConsularUnaCuenta(numeroCuenta);
        }

        private List<RetencionFijaDTO> obtenerRetencionesFijasDeCuenta(CuentaDTO cuenta)
        {
            return cuenta.Retenciones;
        }
    }
}
