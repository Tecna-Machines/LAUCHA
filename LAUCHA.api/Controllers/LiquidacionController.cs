using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.DTOs.SystemaDTO;
using LAUCHA.application.Exceptios;
using LAUCHA.application.interfaces;
using LAUCHA.application.interfaces.V2.Liquidacion;
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
        private readonly IPagarLiquidacionService _pagarLiquidacion;
        private readonly ILogsApp log;
        public LiquidacionController(ILiquidacionService liquidacionService,
                                     IConsultarEmpleadoService empleadoService,
                                     IAgregarCuentaService cuentaService,
                                     IConsultarContratoTrabajoService contratoService,
                                     IConsultarLiquidacionService consultarLiquidacionService,
                                     IGeneradorRecibos generadorRecibos,
                                     ILogsApp log,
                                     IPagarLiquidacionService pagarLiquidacion)
        {
            _liquidacionService = liquidacionService;
            _empleadoService = empleadoService;
            _CuentaService = cuentaService;
            _ContratoService = contratoService;
            _ConsultarLiquidacionService = consultarLiquidacionService;
            _GeneradorRecibos = generadorRecibos;
            this.log = log;
            _pagarLiquidacion = pagarLiquidacion;
        }

        [HttpPost("empleado/{dni}/liquidar")]
        [ProducesResponseType(typeof(LiquidacionDTO), 201)]
        public async Task<IActionResult> LiquidarEmpleado(string dni, DateTime desde, DateTime hasta)
        {
            var result = await _liquidacionService.HacerUnaLiquidacion(dni,
                                                                new PeriodoDTO { Inicio = desde,Fin = hasta},
                                                                false);

            return new JsonResult(result) { StatusCode = 201 };

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

        [HttpPost("empleado/{dni}/simular")]
        public IActionResult ProbarLiquidacion(string dni, DateTime desde, DateTime hasta)
        {
            var result = _liquidacionService.HacerUnaLiquidacion(dni,
                                                                 new PeriodoDTO { Inicio = desde,Fin = hasta},
                                                                 true);

            return new JsonResult(result.Result) { StatusCode = 200 };
        }

        [HttpPost("pago")]
        public IActionResult PagarUnaLiquidacion(CrearPagoLiquidacionDTO pago)
        {
            var result = _pagarLiquidacion.CrearPagoLiquidacion(pago);
            return new JsonResult(result) { StatusCode = 201 };
        }


    }
}
