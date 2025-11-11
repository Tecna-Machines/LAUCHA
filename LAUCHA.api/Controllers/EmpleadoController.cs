using LAUCHA.application.Common.Extensions;
using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.Features.Empleados.CrearEmpleado;
using LAUCHA.application.Features.Empleados.GetEmpleados;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IConsultarEmpleadoService _consultarEmpleadoService;
        private readonly IConsultarContratoTrabajoService _consultarContratoTrabajoService;
        private readonly IGetEmpleados _getEmpleados;
        private readonly ICrearEmpleado _crearEmpleados;
        public EmpleadoController(IConsultarEmpleadoService consultarEmpleadoService,
                                  IConsultarContratoTrabajoService consultarContratoTrabajoService,
                                  IGetEmpleados getEmpleados,
                                  ICrearEmpleado crearEmpleados)
        {
            _consultarEmpleadoService = consultarEmpleadoService;
            _consultarContratoTrabajoService = consultarContratoTrabajoService;
            _getEmpleados = getEmpleados;
            _crearEmpleados = crearEmpleados;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpleadoDTO), 201)]
        public async Task<IResult> CargarNuevo(CrearEmpleadoRequest req)
        {
            var result = await _crearEmpleados.Crear(req);

            return result.Math(
                onSucces: () => Results.Created($"empleado/{result.Value.Dni}", result.Value),
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
