using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.SystemaDTO;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ICrearEmpleadoService _crearEmpleadoService;

        public EmpleadoController(ICrearEmpleadoService crearEmpleadoService)
        {
            _crearEmpleadoService = crearEmpleadoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpleadoDTO), 200)]
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
                return new JsonResult(mensaje) { StatusCode = mensaje.StatusCode};
            }
           
        }
    }
}
