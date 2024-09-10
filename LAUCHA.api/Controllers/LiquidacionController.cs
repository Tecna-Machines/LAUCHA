using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.SystemaDTO;
using LAUCHA.application.Exceptios;
using LAUCHA.application.interfaces;
using LAUCHA.domain.interfaces.IRepositories;
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
        private readonly ILogsApp log;
        public LiquidacionController(ILiquidacionService liquidacionService,
                                     IConsultarEmpleadoService empleadoService,
                                     IAgregarCuentaService cuentaService,
                                     IConsultarContratoTrabajoService contratoService,
                                     IConsultarLiquidacionService consultarLiquidacionService,
                                     IGeneradorRecibos generadorRecibos,
                                     ILogsApp log)
        {
            _liquidacionService = liquidacionService;
            _empleadoService = empleadoService;
            _CuentaService = cuentaService;
            _ContratoService = contratoService;
            _ConsultarLiquidacionService = consultarLiquidacionService;
            _GeneradorRecibos = generadorRecibos;
            this.log = log;
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
            log.LogInformation("se solicito la liquidacion del empleado: {dni}", dni);

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
                log.LogError(e, "ocurrio un problema en el periodo de liquidacion");
                return new JsonResult(new RespuestaSystema { Mensaje = e.Message, StatusCode = e.Codigo }) { StatusCode = e.Codigo };
            }
            catch (ServicioException e)
            {
                log.LogError(e, "ocurrio un problema con un servicio externo");
                return new JsonResult(new RespuestaSystema { Mensaje = e.Message, StatusCode = 500 });
            }
            catch (Exception e)
            {
                log.LogError(e, "ocurrio un problema al liquidar: {m}", e.Message);
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

        [HttpGet]
        [ProducesResponseType(typeof(PaginaDTO<LiquidacionResumenDTO>), 200)]
        public async Task<IActionResult> ConsultarLiquidaciones(string? dniEmp,
                                                            DateTime? fechaLiquidacion,
                                                            DateTime? inicioPeriodo,
                                                            DateTime? finPeriodo,
                                                            string? codigoLiquidacionGeneral,
                                                            int? cantidad,
                                                            int? indice,
                                                            bool? orden)
        {

            var filtros = new FiltroLiquidacion
            {
                CodigoLiquidacionGeneral = codigoLiquidacionGeneral,
                DniEmp = dniEmp,
                FechaLiquidacion = fechaLiquidacion,
                InicioPeriodo = inicioPeriodo,
                FinPeriodo = finPeriodo,
                Orden = orden ?? true
            };

            int index = indice ?? 1;
            int cantidadRegistros = cantidad ?? 10;

            var result = await _ConsultarLiquidacionService.ConsultarLiquidaciones(filtros, index, cantidadRegistros);

            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpGet("{codigoLiquidacion}/recibo")]
        public IActionResult GenerarReciboSueldos(string codigoLiquidacion)
        {
            LiquidacionDTO liquidacion = _ConsultarLiquidacionService.ConsulatarLiquidacion(codigoLiquidacion);
            DateTime fechaIngreso = _empleadoService.ConsultarUnEmpleado(liquidacion.Dni).FechaIngreso;
            // Generar el PDF del recibo
            byte[] pdfBytes = _GeneradorRecibos.GenerarPdfRecibo(liquidacion, fechaIngreso);

            // Devolver el PDF como una descarga
            return File(pdfBytes, "application/pdf", $"{liquidacion.Codigo}_{liquidacion.Empleado}.pdf");
        }

        [HttpPost("empleado/{dni}/simular-liquidar")]
        public IActionResult ProbarLiquidacion(string dni, DateTime desde, DateTime hasta)
        {
            var result = _liquidacionService.HacerUnaLiquidacion(dni,new PeriodoDTO { Inicio = desde,Fin = hasta});

            return new JsonResult(result) { StatusCode = 200 };
        }


    }
}
