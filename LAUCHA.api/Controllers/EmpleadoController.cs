using LAUCHA.application.Common.Extensions;
using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.DiasEspecialesDTOs.AusenciasDTO;
using LAUCHA.application.DTOs.DiasEspecialesDTOs.HabilitacionHsExtraDTO;
using LAUCHA.application.DTOs.DiasEspecialesDTOs.VacacionesDTO;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.SystemaDTO;
using LAUCHA.application.Features.Empleados.CrearEmpleado;
using LAUCHA.application.Features.Empleados.GetEmpleados;
using LAUCHA.application.interfaces;
using LAUCHA.application.interfaces.V2.Credito;
using LAUCHA.application.interfaces.V2.IDiasEspecialesServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IConsultarEmpleadoService _consultarEmpleadoService;
        private readonly IConsultarContratoTrabajoService _consultarContratoTrabajoService;
        private readonly ICrearConsultarVacacionesService _vacacionesService;
        private readonly ICrearConsultarAusencias _ausenciasService;
        private readonly ICrearConsultarHsExtraHabilitadas _hsExtraService;
        private readonly IGetCreditosByDni _getCreditosEmp;
        private readonly IGetEmpleados _getEmpleados;
        private readonly ICrearEmpleado _crearEmpleados;
        public EmpleadoController(IConsultarEmpleadoService consultarEmpleadoService,
                                  IConsultarContratoTrabajoService consultarContratoTrabajoService,
                                  ICrearConsultarVacacionesService vacacionesService,
                                  ICrearConsultarAusencias ausenciasService,
                                  ICrearConsultarHsExtraHabilitadas hsExtraService,
                                  IGetCreditosByDni getCreditosEmp,
                                  IGetEmpleados getEmpleados,
                                  ICrearEmpleado crearEmpleados)
        {
            _consultarEmpleadoService = consultarEmpleadoService;
            _consultarContratoTrabajoService = consultarContratoTrabajoService;
            _vacacionesService = vacacionesService;
            _ausenciasService = ausenciasService;
            _hsExtraService = hsExtraService;
            _getCreditosEmp = getCreditosEmp;
            _getEmpleados = getEmpleados;
            _crearEmpleados = crearEmpleados;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpleadoDTO), 201)]
        public async Task<IResult> CargarNuevo(CrearEmpleadoRequest req)
        {
            var result = await _crearEmpleados.Crear(req);

            return result.Math(
                onSucces: () => Results.Created($"empleado/{result.Value.Dni}",result.Value),
                onFailure: error => Results.BadRequest(error));
        }

        [HttpGet]
        public async Task<IResult> ConsultarEmpleados()
        {
            var result = await _getEmpleados.GetEmpleados();
            return result.Math(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }


        [HttpGet("{dni}")]
        [ProducesResponseType(typeof(EmpleadoDTO), 200)]
        public IActionResult ObtenerEmpleado(string dni)
        {
            var result = _consultarEmpleadoService.ConsultarUnEmpleado(dni);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{dni}/acuerdos")]
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



    }
}
