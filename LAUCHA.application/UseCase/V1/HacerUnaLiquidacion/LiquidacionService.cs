using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.Exceptios;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;

namespace LAUCHA.application.UseCase.HacerUnaLiquidacion
{
    public class CrearLiquidacionService : ILiquidacionService
    {
        private readonly ILogsApp log;
        private IEstrategiaCalcularSueldo _CalculadoraSueldo = null!;
        private IFabricaCalculadoraSueldo _FabricaCalculadora;
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly IRecuperarItemsParaLiquidacion _RecuperarItemsLiquidacion;
        private readonly ICalculadoraAntiguedad _CalculadoraAntiguedad;
        private readonly IConsultarContratoTrabajoService _ConsultarContrato;

        private readonly IUnitOfWorkLiquidacion _UnitOfWorkLiquidacion;

        private RemuneracionMapper _MapperRemuneracion;
        private RetencionMapper _MapperRetenciones;
        private LiquidacionMapper _MapperLiquidacion;


        private ContratoDTO? _Contrato;
        private CuentaDTO? _Cuenta;
        private Empleado? _Empleado;

        private DateTime _InicioPeriodo;
        private DateTime _FinPeriodo;

        public CrearLiquidacionService(IFabricaCalculadoraSueldo fabricaCalculadora,
                                       IUnitOfWorkLiquidacion unitOfWorkLiquidacion,
                                       IGenericRepository<Empleado> empleadoRepository,
                                       IRecuperarItemsParaLiquidacion recuperarItemsLiquidacion,
                                       ICalculadoraAntiguedad calculadoraAntiguedad,
                                       IConsultarContratoTrabajoService consultarContrato,
                                       ILogsApp log)
        {
            _MapperRemuneracion = new();
            _MapperRetenciones = new();
            _MapperLiquidacion = new();

            _FabricaCalculadora = fabricaCalculadora;
            _UnitOfWorkLiquidacion = unitOfWorkLiquidacion;
            _EmpleadoRepository = empleadoRepository;
            _RecuperarItemsLiquidacion = recuperarItemsLiquidacion;
            _CalculadoraAntiguedad = calculadoraAntiguedad;
            _ConsultarContrato = consultarContrato;
            this.log = log;
        }

        public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp)
        {
            log.LogInformation("seteando empleado para liquidacion del periodo: ini: {i} , fin: {f}"
                               , inicioPeriodo, finPeriodo);

            TimeSpan diferencionFechas = finPeriodo - inicioPeriodo;
            int diasPeriodo = diferencionFechas.Days;

            if (diasPeriodo > 31)
            {
                log.LogError("Se seteo un periodo mayor a 31 dias");
                throw new PeriodoExcepcion("el periodo no puede ser mayor a 31 dias");
            }

            if (inicioPeriodo > finPeriodo)
            {
                log.LogError(null, "la fecha de inicio del periodo: {i} , es menor al fin del periodo: {f}", inicioPeriodo, finPeriodo);
                throw new PeriodoExcepcion("el inicio de periodo  es menor que el fin del periodo");
            }

            if (inicioPeriodo == finPeriodo)
            {
                log.LogError(null, "se seteo la misma fecha para inicio y final de periodo: {f}", inicioPeriodo);
                throw new PeriodoExcepcion("no pueden utilizarse las mismas fechas para liquidar");
            }

            _Contrato = contratoEmp;
            _Cuenta = cuentaEmp;
            _Empleado = _EmpleadoRepository.GetById(_Contrato.Dni);

            _InicioPeriodo = inicioPeriodo;
            _FinPeriodo = finPeriodo;

            int codigoModalidad = int.Parse(_Contrato.Modalidad.Codigo);

            log.LogInformation("se seteo el empleado: {name},{ap}", _Empleado.Nombre, _Empleado.Apellido);
            log.LogInformation("el contrato seleccionado fue el contrato N: {c}", _Contrato.Codigo);

            _CalculadoraSueldo = _FabricaCalculadora.CrearCalculadoraSueldo(codigoModalidad);
        }


        public DeduccionDTOs HacerDeduccionesSueldo()
        {
            log.LogInformation("INICIO deduccion de sueldo");

            decimal montoBrutoBlanco = 0;

            List<RetencionDTO> retencionesDTO = new();
            List<RemuneracionDTO> remuneracionesDTO = new();

            log.LogInformation("calculando las remuneraciones del sueldo");

            List<Remuneracion> remuneracionesSueldo = _CalculadoraSueldo.CalcularSueldoBruto(this._InicioPeriodo, this._FinPeriodo, _Contrato!, _Cuenta!);

            if (remuneracionesSueldo.Count < 1)
            {
                log.LogError("el calculo de las remuneraciones obtuvo menos de 1 remuneracion ");
                throw new SueldoException("no se pudieron calcular remuneraciones");
            }

            log.LogInformation("se calcularon las remuneraciones de la deduccion");

            foreach (var remuneracionNueva in remuneracionesSueldo)
            {
                log.LogInformation("remuneracion: {c} ,monto: {m},descrip: {d},esBlanco:{b}"
                    , remuneracionNueva.CodigoRemuneracion, remuneracionNueva.Monto, remuneracionNueva.Descripcion, remuneracionNueva.EsBlanco);

                if (remuneracionNueva.EsBlanco)
                {
                    log.LogInformation("la remuneracion: {c} es blanca", remuneracionNueva.CodigoRemuneracion);
                    log.LogInformation("monto de la remuneracion: {m}", remuneracionNueva.Monto);

                    montoBrutoBlanco = +remuneracionNueva.Monto;

                    log.LogInformation("el monto bruto en blanco fue actualizado: {m}", montoBrutoBlanco);
                }

                _UnitOfWorkLiquidacion.RemuneracionRepository.Insert(remuneracionNueva);

                var remuneracionDTO = _MapperRemuneracion.GenerarRemuneracionDTO(remuneracionNueva);
                remuneracionesDTO.Add(remuneracionDTO);
            }

            Remuneracion antiguedadRemuneracion = _CalculadoraAntiguedad.CalcularAntiguedad(null, montoBrutoBlanco);

            log.LogInformation("se calculo la antiguedad en: {d} y monto: {m}",
                antiguedadRemuneracion.Descripcion, antiguedadRemuneracion.Monto);

            _UnitOfWorkLiquidacion.RemuneracionRepository.Insert(antiguedadRemuneracion);
            remuneracionesDTO.Add(_MapperRemuneracion.GenerarRemuneracionDTO(antiguedadRemuneracion));

            var retenciones = _CalculadoraSueldo.CalcularRetencionesSueldo((montoBrutoBlanco + antiguedadRemuneracion.Monto), _Cuenta!);

            log.LogInformation("se calcularon las retenciones ,cant. de retenciones: {c}", retenciones.Count);

            foreach (var retencionNueva in retenciones)
            {
                log.LogInformation("agregando retencion: desc: {d},monto: {m}", retencionNueva.Descripcion, retencionNueva.Monto);

                Retencion retencion = _UnitOfWorkLiquidacion.RetencionRepository.Insert(retencionNueva);
                var retencionDTO = _MapperRetenciones.GenerarRetencionDTO(retencion);
                retencionesDTO.Add(retencionDTO);
            }

            //guardar nuevas remuneraciones y retenciones
            log.LogInformation("se estan almacenado las retenciones, cant. {rc}", retenciones.Count);
            log.LogInformation("se estan almacenado las remuneraciones, cant. {rc}", remuneracionesSueldo.Count);

            _UnitOfWorkLiquidacion.Save();

            log.LogInformation("Devolviendo deducciones");
            log.LogInformation("FIN de deducciones de sueldo");

            return new DeduccionDTOs
            {
                Empleado = _Cuenta!.Empleado,
                InicioPeriodo = this._InicioPeriodo,
                FinPeriodo = this._FinPeriodo,
                Remuneraciones = remuneracionesDTO,
                Retenciones = retencionesDTO
            };
        }

        public async Task<LiquidacionDTO> HacerUnaLiquidacion()
        {

            if (_Contrato == null || _Empleado == null)
            {
                log.LogError("no se han seteado correctamente el empleado o el contrato");
                throw new ArgumentNullException();
            }

            string nombreEmp = $"{_Empleado.Nombre} {_Empleado.Apellido}";

            log.LogInformation("INICIO de liquidacion");
            log.LogInformation("empleado seteado: {e}, contrato seteado: {c}", nombreEmp, _Contrato.Codigo);

            DateTime fechaActual = DateTime.Now;

            int numeroQuincena = fechaActual.Day < 15 ? 1 : 2;

            log.LogInformation("el sistema determino que la quincena es: {q}", numeroQuincena);

            decimal totalRemunerativo = 0;
            decimal totalNoRemunerativo = 0;
            decimal totalRetenciones = 0;
            decimal totalDescuentos = 0;

            string codigoNuevaLiquidacion = $"{fechaActual.Year}{fechaActual.Month}{numeroQuincena}-{_Contrato?.Dni}";

            log.LogInformation("el codigo de liquidacion sera: {cl}", codigoNuevaLiquidacion);

            LiquidacionPersonal nuevaLiquidacion = new()
            {
                CodigoLiquidacion = codigoNuevaLiquidacion,
                Concepto = $"liquidacion de sueldo {this._Cuenta!.Empleado}",
                InicioPeriodo = _InicioPeriodo,
                FinPeriodo = _FinPeriodo,
                FechaLiquidacion = fechaActual,
                CodigoContrato = this._Contrato!.Codigo
            };

            //insertar liquidacion
            log.LogInformation("almacenmiento temporal de liquidacion (aun no en BD)");
            _UnitOfWorkLiquidacion.LiquidacionRepository.Insert(nuevaLiquidacion);

            //logica para traer remuneracion , retenciones y descuentos para crear la liquidacion
            string numeroCuenta = _Cuenta.NumeroCuenta;
            string dniEmp = _Empleado?.Dni!;

            List<Remuneracion> remuneraciones = await _RecuperarItemsLiquidacion.ObtenerRemuneracionesParaLiquidacion(numeroCuenta, _InicioPeriodo, _FinPeriodo);
            List<Retencion> retenciones = await _RecuperarItemsLiquidacion.ObtenerRetencionesParaLiquidacion(numeroCuenta, _InicioPeriodo, _FinPeriodo);
            List<Descuento> descuentos = await _RecuperarItemsLiquidacion.ObtenerDescuentosParaLiquidacion(numeroCuenta, dniEmp, _InicioPeriodo, _FinPeriodo);
            List<NoRemuneracion> noRemuneraciones = await _RecuperarItemsLiquidacion.ObtenerNoRemunerativoParaLiquidacion(numeroCuenta, _InicioPeriodo, _FinPeriodo);


            foreach (var remu in remuneraciones)
            {
                var remuLiquidacion = new RemuneracionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoRemuneracion = remu.CodigoRemuneracion
                };

                log.LogInformation("asociando remuneracion: {c} , con liquidacion: {l}"
                                    , remuLiquidacion.CodigoRemuneracion, remuLiquidacion.CodigoLiquidacionPersonal);

                totalRemunerativo += remu.Monto;

                log.LogInformation("se actualizo el monto remunerativo: ${m}", totalRemunerativo);

                _UnitOfWorkLiquidacion.RemuneracionLiquidacion.Insert(remuLiquidacion);
            }

            foreach (var reten in retenciones)
            {
                var retenLiquidacion = new RetencionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoRetencion = reten.CodigoRetencion
                };

                log.LogInformation("asociando retencion: {c} , con liquidacion: {l}"
                    , retenLiquidacion.CodigoRetencion, retenLiquidacion.CodigoLiquidacionPersonal);

                totalRetenciones += reten.Monto;

                log.LogInformation("se actualizo el monto de retenciones: ${m}", totalRetenciones);

                _UnitOfWorkLiquidacion.RetencionLiquidacion.Insert(retenLiquidacion);
            }

            foreach (var desc in descuentos)
            {
                var desLiquidacion = new DescuentoPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoDescuento = desc.CodigoDescuento
                };

                log.LogInformation("asociando descuento: {c} , con liquidacion: {l}"
                    , desLiquidacion.CodigoDescuento, desLiquidacion.CodigoLiquidacionPersonal);

                totalDescuentos += desc.Monto;

                log.LogInformation("se actualizo el monto de descuento: ${m}", totalDescuentos);

                _UnitOfWorkLiquidacion.DescuentoLiquidacion.Insert(desLiquidacion);
            }

            foreach (var noRemu in noRemuneraciones)
            {
                var noRemuLiquidacions = new NoRemuneracionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoNoRemuneracion = noRemu.CodigoNoRemuneracion
                };

                log.LogInformation("asociando no remuneracion: {c} , con liquidacion: {l}"
                            , noRemuLiquidacions.CodigoNoRemuneracion, noRemuLiquidacions.CodigoLiquidacionPersonal);

                totalNoRemunerativo += noRemu.Monto;

                log.LogInformation("se actualizo el monto no remunerativo: ${m}", totalNoRemunerativo);

                _UnitOfWorkLiquidacion.NoRemuneracionLiquidacion.Insert(noRemuLiquidacions);
            }

            //confirmar liquidacion
            nuevaLiquidacion.TotalRemuneraciones = totalRemunerativo;
            nuevaLiquidacion.TotalNoRemunerativo = totalNoRemunerativo;
            nuevaLiquidacion.TotalDescuentos = totalDescuentos;
            nuevaLiquidacion.TotalRetenciones = totalRetenciones;

            log.LogInformation("monto remunerativo calculado: {r}", totalRemunerativo);
            log.LogInformation("monto NO remunerativo calculado: {nr}", totalNoRemunerativo);
            log.LogInformation("monto descuentos calculado: {d}", totalDescuentos);
            log.LogInformation("monto retenciones calculado: {re}", totalRetenciones);

            _UnitOfWorkLiquidacion.LiquidacionRepository.Update(nuevaLiquidacion);
            _UnitOfWorkLiquidacion.Save();


            var pagos = new List<PagoLiquidacion>();

            Empleado empleado = this._Empleado ?? throw new NullReferenceException();

            var contrato = _ConsultarContrato.ConsultarContrato(nuevaLiquidacion.CodigoContrato);

            log.LogInformation("FIN de liquidacion, liquidacion condigo: {c}", nuevaLiquidacion.CodigoLiquidacion);

            return _MapperLiquidacion.GenerarLiquidacionDTO(nuevaLiquidacion, remuneraciones,
                                                            retenciones, descuentos, noRemuneraciones, pagos, empleado, contrato);
        }

        public Task<LiquidacionDTO> HacerUnaLiquidacion(string dni, PeriodoDTO periodo)
        {
            throw new NotImplementedException();
        }
    }
}
