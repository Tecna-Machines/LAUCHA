using LAUCHA.application.Common.Extensions;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado;
using LAUCHA.application.Features.Empleados.CrearEmpleado;
using LAUCHA.application.Features.Empleados.GetEmpleados;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IGetEmpleados _getEmpleados;
        private readonly ICrearEmpleado _crearEmpleados;
        private readonly IGetAcuerdosEmpleado _acuerdos;
        public EmpleadoController(IGetEmpleados getEmpleados,
                                  ICrearEmpleado crearEmpleados,
                                  IGetAcuerdosEmpleado acuerdos)
        {
            _getEmpleados = getEmpleados;
            _crearEmpleados = crearEmpleados;
            _acuerdos = acuerdos;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpleadoDTO), 201)]
        public async Task<IResult> CargarNuevo(CrearEmpleadoRequest req)
        {
            var result = await _crearEmpleados.Crear(req);

            return result.Match(
                onSucces: () => Results.Created($"empleado/{result.Value.Dni}", result.Value),
                onFailure: error => Results.BadRequest(error));
        }

        [HttpGet]
        public async Task<IResult> ConsultarEmpleados()
        {
            var result = await _getEmpleados.GetEmpleados();
            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }


        [HttpGet("{dni}")]
        [ProducesResponseType(typeof(EmpleadoDTO), 200)]
        public IActionResult ObtenerEmpleado(string dni)
        {
            throw new NotImplementedException("falta.implementar");
        }

        [HttpGet("{dni}/acuerdos")]
        [ProducesResponseType(typeof(ContratoDTO), 200)]
        public async Task<IResult> GetHistorialAcuerdos(string dni)
        {
            var result = await _acuerdos.GetAcuerdosEmpleado(new GetAcuerdosEmpleadoRequest(dni));
            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }


    }
}
