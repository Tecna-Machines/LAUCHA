using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.Entities.Liquidacion;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ConsultarLiquidacion
{
    public class ConsularLiquidacionService : IConsultarLiquidacionService
    {
        private readonly LiquidacionMapper _MapperLiquidacion;
        private readonly IItemsLiquidacionRepository _ItemsLiquidacionRepository;
        private readonly IGenericRepository<Liquidacion> _LiquidacionRepository;
        private readonly IGenericRepository<Cuenta> _CuentaRepository;
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly ILiquidacionRepository _LiquidacionRepositoyEspecifico;
        private readonly IConsultarContratoTrabajoService _ConsultarContratoService;
        private readonly ILogsApp log;

        public ConsularLiquidacionService(IGenericRepository<Liquidacion> liquidacionRepository,
                                          IItemsLiquidacionRepository itemsLiquidacionRepository,
                                          IGenericRepository<Cuenta> cuentaRepository,
                                          IGenericRepository<Empleado> empleadoRepository,
                                          ILiquidacionRepository liquidacionRepositoyEspecifico,
                                          IConsultarContratoTrabajoService consultarContratoService,
                                          ILogsApp log)
        {
            _MapperLiquidacion = new();
            _LiquidacionRepository = liquidacionRepository;
            _ItemsLiquidacionRepository = itemsLiquidacionRepository;
            _CuentaRepository = cuentaRepository;
            _EmpleadoRepository = empleadoRepository;
            _LiquidacionRepositoyEspecifico = liquidacionRepositoyEspecifico;
            _ConsultarContratoService = consultarContratoService;
            this.log = log;
        }

        public LiquidacionDTO ConsulatarLiquidacion(string codigoLiquidacion)
        {
            log.LogInformation("se esta consultando por la liquidacion: {cod}", codigoLiquidacion);

            Liquidacion liquidacion = _LiquidacionRepository.GetById(codigoLiquidacion);

            List<Retencion> retenciones = _ItemsLiquidacionRepository.ObtenerRetencionesLiquidacion(codigoLiquidacion);
            List<Remuneracion> remuneraciones = _ItemsLiquidacionRepository.ObtenerRemuneracionesLiquidacion(codigoLiquidacion);
            List<Descuento> descuentos = _ItemsLiquidacionRepository.ObtenerDescuentosLiquidacion(codigoLiquidacion);
            List<NoRemuneracion> noRemuneraciones = _ItemsLiquidacionRepository.ObtenerNoRemuneracionesLiquidacion(codigoLiquidacion);

            List<PagoLiquidacion> pagos = _ItemsLiquidacionRepository.ObtenerPagosLiquidacion(codigoLiquidacion);

            string numeroCuenta = retenciones[0].NumeroCuenta;

            Cuenta cuenta = _CuentaRepository.GetById(numeroCuenta);
            Empleado empleado = _EmpleadoRepository.GetById(cuenta.DniEmpleado);

            var contrato = _ConsultarContratoService.ConsultarContrato(liquidacion.CodigoAcuerdo);

            return _MapperLiquidacion.GenerarLiquidacionDTO(liquidacion, remuneraciones, retenciones, descuentos, noRemuneraciones, pagos, empleado, contrato);
        }

        public async Task<PaginaDTO<LiquidacionResumenDTO>> ConsultarLiquidaciones(FiltroLiquidacion filtros, int indice, int cantidadRegistros)
        {
            log.LogInformation("se esta consultando por varias liquidaciones");

            PaginaRegistro<Liquidacion> pagina = await _LiquidacionRepositoyEspecifico
                                                               .ConseguirLiquidacionesFiltradas(filtros, indice, cantidadRegistros);

            List<LiquidacionResumenDTO> liquidacionesResumenDTOs = new();
            List<Liquidacion> liquidaciones = pagina.Registros;

            foreach (var liq in liquidaciones)
            {
                log.LogInformation("Devoliendo la liquidacion N: {n}", liq.Codigo);

                var liquidacionDTO = new LiquidacionResumenDTO
                {
                    Codigo = liq.Codigo,
                    TotalDescuentos = liq.TotalDescuentos,
                    TotalNoRemunerativo = liq.TotalNoRemunerativo,
                    Fecha = liq.FechaLiquidacion,
                    Concepto = liq.Concepto,
                    Periodo = new PeriodoDTO
                    {
                        Inicio = liq.InicioPeriodo,
                        Fin = liq.FinPeriodo
                    },
                    TotalRemuneraciones = liq.TotalRemuneraciones,
                    TotalRetenciones = liq.TotalRetenciones
                };

                liquidacionesResumenDTOs.Add(liquidacionDTO);
            }

            return new PaginaDTO<LiquidacionResumenDTO>
            {
                Index = pagina.indicePagina,
                TotalEncontrados = pagina.totalRegistros,
                Paginas = pagina.totalPaginas,
                Resultados = liquidacionesResumenDTOs
            };
        }
    }
}
