using iText.Kernel.Pdf;
using iText.Layout.Element;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.SystemaDTO;
using LAUCHA.application.Exceptios;
using LAUCHA.application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAUCHA.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LiquidacionController : ControllerBase
    {
        private readonly ILiquidacionService _liquidacionService;
        private readonly IConsultarEmpleadoService _empleadoService;
        private readonly IAgregarCuentaService _CuentaService;
        private readonly IConsultarContratoTrabajoService _ContratoService;
        private readonly IConsultarLiquidacionService _ConsultarLiquidacionService;
        private readonly IGeneradorRecibos _GeneradorRecibos;
        public LiquidacionController(ILiquidacionService liquidacionService,
                                     IConsultarEmpleadoService empleadoService,
                                     IAgregarCuentaService cuentaService,
                                     IConsultarContratoTrabajoService contratoService,
                                     IConsultarLiquidacionService consultarLiquidacionService,
                                     IGeneradorRecibos generadorRecibos)
        {
            _liquidacionService = liquidacionService;
            _empleadoService = empleadoService;
            _CuentaService = cuentaService;
            _ContratoService = contratoService;
            _ConsultarLiquidacionService = consultarLiquidacionService;
            _GeneradorRecibos = generadorRecibos;
        }

        [HttpPost("empleado/{dni}/deducir-retenciones")]
        [ProducesResponseType(typeof(DeduccionDTOs), 201)]
        public IActionResult HacerDeducciones(string dni, DateTime desde, DateTime hasta)
        {
            var empleado = _empleadoService.ConsultarUnEmpleado(dni);

            var cuenta = _CuentaService.ConsularUnaCuenta(empleado.NumeroCuenta);
            var contrato = _ContratoService.ObtenerContratoDeEmpleado(empleado.Dni);

            _liquidacionService.SetearEmpleadoALiquidar(desde, hasta, contrato, cuenta);
            var result = _liquidacionService.HacerDeduccionesSueldo();

            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpPost("empleado/{dni}/liquidar")]
        [ProducesResponseType(typeof(LiquidacionDTO), 201)]
        public async Task<IActionResult> LiquidarEmpleado(string dni, DateTime desde, DateTime hasta)
        {
            try
            {
                var empleado = _empleadoService.ConsultarUnEmpleado(dni);

                var cuenta = _CuentaService.ConsularUnaCuenta(empleado.NumeroCuenta);
                var contrato = _ContratoService.ObtenerContratoDeEmpleado(empleado.Dni);

                _liquidacionService.SetearEmpleadoALiquidar(desde, hasta, contrato, cuenta);
                var result = await _liquidacionService.HacerUnaLiquidacion();

                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (PeriodoExcepcion e)
            {
                return new JsonResult(new RespuestaSystema { Mensaje = e.Message, StatusCode = e.Codigo }) { StatusCode = e.Codigo };
            }
            catch (Exception e)
            {
                return new JsonResult(new RespuestaSystema { Mensaje = e.Message, StatusCode = 500 }) { StatusCode = 500 };
            }

        }

        [HttpGet("{codigoLiquidacion}")]
        [ProducesResponseType(typeof(LiquidacionDTO), 200)]
        public IActionResult ConsularLiquidacion(string codigoLiquidacion)
        {
            var result = _ConsultarLiquidacionService.ConsulatarLiquidacion(codigoLiquidacion);

            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("/recibo/{codigoLiquidacion}")]
        public IActionResult GenerarReciboSueldos(string codigoLiquidacion)
        {
            LiquidacionDTO liquidacion = _ConsultarLiquidacionService.ConsulatarLiquidacion(codigoLiquidacion);
            // Generar el PDF del recibo
            byte[] pdfBytes = _GeneradorRecibos.GenerarPdfRecibo(liquidacion);

            // Devolver el PDF como una descarga
            return File(pdfBytes, "application/pdf", $"{liquidacion.Codigo}_{liquidacion.Empleado}.pdf");
        }


    }
}
