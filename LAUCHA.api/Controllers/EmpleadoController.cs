using iText.Pdfua.Checkers.Utils.Ua1;
using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado;
using LAUCHA.application.Features.Empleados.CrearEmpleado;
using LAUCHA.application.Features.Empleados.GetEmpleadoAsistencias;
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
        private readonly IGetEmpleadoAsistencias _asistencias;
        public EmpleadoController(IGetEmpleados getEmpleados,
                                  ICrearEmpleado crearEmpleados,
                                  IGetAcuerdosEmpleado acuerdos,
                                  IGetEmpleadoAsistencias asistencias)
        {
            _getEmpleados = getEmpleados;
            _crearEmpleados = crearEmpleados;
            _acuerdos = acuerdos;
            _asistencias = asistencias;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CrearEmpleadoResponse), 201)]
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


        [HttpGet("{dni}/acuerdos")]
        public async Task<IResult> GetHistorialAcuerdos(string dni)
        {
            var result = await _acuerdos.GetAcuerdosEmpleado(new GetAcuerdosEmpleadoRequest(dni));
            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }

        [HttpGet("/api/v1/empleados/{dni}/asistencias")]
        public async Task<IResult> GetAsistencias(string dni,DateTime Inicio,DateTime Fin)
        {
            var result = await _asistencias.GetAsistencias(new GetEmpleadoAsistenciaRequest(dni,Inicio,Fin));
            return result.Match(
                onSucces: () => Results.Ok(result.Value),
                onFailure: error => Results.BadRequest(error));
        }


    }
}
