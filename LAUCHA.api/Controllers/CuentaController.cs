﻿using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly IAgregarCuentaService _cuentaService;

        public CuentaController(IAgregarCuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarUnaCuenta(string id)
        {
            var result = _cuentaService.ConsularUnaCuenta(id);
            return new JsonResult(result) { StatusCode = 200};
        }

        [HttpPost("{id}/retenciones-fijas")]
        public IActionResult ConsultarRetencionesFijasDeCuenta(string id,string[] codigosRetenciones)
        {
            var result = _cuentaService.AgregarRetencionesFijas(id,codigosRetenciones);
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}