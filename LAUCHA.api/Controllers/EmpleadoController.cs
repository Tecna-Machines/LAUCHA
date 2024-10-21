using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.DiasEspecialesDTOs.AusenciasDTO;
using LAUCHA.application.DTOs.DiasEspecialesDTOs.HabilitacionHsExtraDTO;
using LAUCHA.application.DTOs.DiasEspecialesDTOs.VacacionesDTO;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.SystemaDTO;
using LAUCHA.application.interfaces;
using LAUCHA.application.interfaces.V2.Credito;
using LAUCHA.application.interfaces.V2.IDiasEspecialesServices;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ICrearEmpleadoService _crearEmpleadoService;
        private readonly IConsultarEmpleadoService _consultarEmpleadoService;
        private readonly IConsultarContratoTrabajoService _consultarContratoTrabajoService;
        private readonly ICrearConsultarVacacionesService _vacacionesService;
        private readonly ICrearConsultarAusencias _ausenciasService;
        private readonly ICrearConsultarHsExtraHabilitadas _hsExtraService;
        private readonly IGetCreditosByDni _getCreditosEmp;

        public EmpleadoController(ICrearEmpleadoService crearEmpleadoService,
                                  IConsultarEmpleadoService consultarEmpleadoService,
                                  IConsultarContratoTrabajoService consultarContratoTrabajoService,
                                  ICrearConsultarVacacionesService vacacionesService,
                                  ICrearConsultarAusencias ausenciasService,
                                  ICrearConsultarHsExtraHabilitadas hsExtraService,
                                  IGetCreditosByDni getCreditosEmp)
        {
            _crearEmpleadoService = crearEmpleadoService;
            _consultarEmpleadoService = consultarEmpleadoService;
            _consultarContratoTrabajoService = consultarContratoTrabajoService;
            _vacacionesService = vacacionesService;
            _ausenciasService = ausenciasService;
            _hsExtraService = hsExtraService;
            _getCreditosEmp = getCreditosEmp;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpleadoDTO), 201)]
        public IActionResult CrearNuevoEmpleado(CrearEmpleadoDTO nuevoEmpleado)
        {
            try
            {
                var empleado = _crearEmpleadoService.CargarNuevoEmpleado(nuevoEmpleado);
                return new JsonResult(empleado) { StatusCode = 201 };
            }
            catch (Exception)
            {
                var mensaje = new RespuestaSystema { Mensaje = "ocurrio un problema", StatusCode = 500 };
                return new JsonResult(mensaje) { StatusCode = mensaje.StatusCode };
            }

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EmpleadoDTO>), 200)]
        public IActionResult ObtenerTodosLosEmpleados()
        {
            var result = _consultarEmpleadoService.ConsultarTodosLosEmpleados();
            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet("{dni}")]
        [ProducesResponseType(typeof(EmpleadoDTO), 200)]
        public IActionResult ObtenerEmpleado(string dni)
        {
            var result = _consultarEmpleadoService.ConsultarUnEmpleado(dni);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{dni}/contrato")]
        [ProducesResponseType(typeof(ContratoDTO), 200)]
        public IActionResult ObtenerContratoEmpleado(string dni)
        {
            var result = _consultarContratoTrabajoService.ObtenerContratoDeEmpleado(dni);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{dni}/contratos")]
        public IActionResult ObtenerLosContratosDeUnEmpleado(string dni)
        {
            var result = _consultarContratoTrabajoService.ObtenerTodosLosContratosDeEmpleado(dni);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpPost("vacaciones")]
        public IActionResult CrearVacaciones(CrearVacacionesDTO vacaciones)
        {
            var result = _vacacionesService.crearNuevaVacacion(vacaciones);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{dni}/vacaciones")]
        public IActionResult ConsultarVacacionesEmpleado(string dni, int? anio)
        {
            var result = _vacacionesService.obtenerVacacionesEmpleado(dni, anio);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpPost("ausencia")]
        public IActionResult AgregarAusencia(CrearAusenciaDTO ausencia)
        {
            var result = _ausenciasService.crearAusencia(ausencia);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{dni}/ausencias")]
        public IActionResult ConsultarAusencias(string dni, int? anio)
        {
            var result = _ausenciasService.obtenerAusenciasEmpleado(dni, anio);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{dni}/creditos")]
        public IActionResult ConsultarCreditos(string dni)
        {
            var result = _getCreditosEmp.ObtenerCreditosDeUnEmpleado(dni);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpPost("habilitar-hs-extra")]
        public IActionResult AgregarPermisoHsExtra(CrearHabilitacionHsExtraDTO hsExtra)
        {
            var result = _hsExtraService.crearPermisoHsExtra(hsExtra);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{dni}/habilitar-hs-extra")]
        public IActionResult ConsultarHsExtraHabilitadas(string dni, DateTime inicioPeriodo, DateTime finPeriodo)
        {
            var result = _hsExtraService.verPermisoHsExtraPeriodoEmpleado(dni, inicioPeriodo, finPeriodo);
            return new JsonResult(result) { StatusCode = 200 };
        }


    }
}
