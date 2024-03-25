﻿using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.application.DTOs.SystemaDTO;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using Microsoft.AspNetCore.Http;
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

        public EmpleadoController(ICrearEmpleadoService crearEmpleadoService, 
                                  IConsultarEmpleadoService consultarEmpleadoService, 
                                  IConsultarContratoTrabajoService consultarContratoTrabajoService)
        {
            _crearEmpleadoService = crearEmpleadoService;
            _consultarEmpleadoService = consultarEmpleadoService;
            _consultarContratoTrabajoService = consultarContratoTrabajoService;
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
                return new JsonResult(mensaje) { StatusCode = mensaje.StatusCode};
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

    }
}
