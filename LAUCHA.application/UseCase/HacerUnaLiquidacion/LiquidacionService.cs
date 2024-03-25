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
                                       IConsultarContratoTrabajoService consultarContrato)
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
        }

        public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp)
        {
            TimeSpan diferencionFechas = finPeriodo - inicioPeriodo;
            int diasPeriodo = diferencionFechas.Days;

            if (diasPeriodo > 31) { throw new PeriodoExcepcion("el periodo no puede ser mayor a 31 dias"); }

            if (inicioPeriodo > finPeriodo) { throw new PeriodoExcepcion("el inicio de periodo  es menor que el fin del periodo"); }

            if (inicioPeriodo == finPeriodo) { throw new PeriodoExcepcion("no pueden utilizarse las mismas fechas para liquidar"); }

            _Contrato = contratoEmp;
            _Cuenta = cuentaEmp;
            _Empleado = _EmpleadoRepository.GetById(_Contrato.Dni);

            _InicioPeriodo = inicioPeriodo;
            _FinPeriodo = finPeriodo;

            int codigoModalidad = int.Parse(_Contrato.Modalidad.Codigo);
            _CalculadoraSueldo = _FabricaCalculadora.CrearCalculadoraSueldo(codigoModalidad);
        }


        public DeduccionDTOs HacerDeduccionesSueldo()
        {
            decimal montoBrutoBlanco = 0;

            List<RetencionDTO> retencionesDTO = new();
            List<RemuneracionDTO> remuneracionesDTO = new();

            List<Remuneracion> remuneracionesSueldo = _CalculadoraSueldo.CalcularSueldoBruto(this._InicioPeriodo, this._FinPeriodo, _Contrato!, _Cuenta!);

            if (remuneracionesSueldo.Count < 1) { throw new SueldoException("no se pudieron calcular remuneraciones"); }

            foreach (var remuneracionNueva in remuneracionesSueldo)
            {
                if (remuneracionNueva.EsBlanco) { montoBrutoBlanco = +remuneracionNueva.Monto; }

                _UnitOfWorkLiquidacion.RemuneracionRepository.Insert(remuneracionNueva);

                var remuneracionDTO = _MapperRemuneracion.GenerarRemuneracionDTO(remuneracionNueva);
                remuneracionesDTO.Add(remuneracionDTO);
            }

            Remuneracion antiguedadRemuneracion = _CalculadoraAntiguedad.CalcularAntiguedad(this._Empleado!,montoBrutoBlanco);

            _UnitOfWorkLiquidacion.RemuneracionRepository.Insert(antiguedadRemuneracion);
            remuneracionesDTO.Add(_MapperRemuneracion.GenerarRemuneracionDTO(antiguedadRemuneracion));

            var retenciones = _CalculadoraSueldo.CalcularRetencionesSueldo((montoBrutoBlanco+antiguedadRemuneracion.Monto), _Cuenta!);

            foreach (var retencionNueva in retenciones)
            {
                Retencion retencion = _UnitOfWorkLiquidacion.RetencionRepository.Insert(retencionNueva);
                var retencionDTO = _MapperRetenciones.GenerarRetencionDTO(retencion);
                retencionesDTO.Add(retencionDTO);
            }

            //guardar nuevas remuneraciones y retenciones
            _UnitOfWorkLiquidacion.Save();

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
            DateTime fechaActual = DateTime.Now;

            int numeroQuincena = fechaActual.Day < 15 ? 1 : 2;

            decimal totalRemunerativo = 0;
            decimal totalNoRemunerativo = 0;
            decimal totalRetenciones = 0;
            decimal totalDescuentos = 0;

            string codigoNuevaLiquidacion = $"{fechaActual.Year}{fechaActual.Month}{numeroQuincena}-{_Contrato?.Dni}";

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

                totalRemunerativo += remu.Monto;

                _UnitOfWorkLiquidacion.RemuneracionLiquidacion.Insert(remuLiquidacion);
            }

            foreach (var reten in retenciones)
            {
                var retenLiquidacion = new RetencionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoRetencion = reten.CodigoRetencion
                };

                totalRetenciones += reten.Monto;

                _UnitOfWorkLiquidacion.RetencionLiquidacion.Insert(retenLiquidacion);
            }

            foreach (var desc in descuentos)
            {
                var desLiquidacion = new DescuentoPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoDescuento = desc.CodigoDescuento
                };

                totalDescuentos += desc.Monto;

                _UnitOfWorkLiquidacion.DescuentoLiquidacion.Insert(desLiquidacion);
            }

            foreach (var noRemu in noRemuneraciones)
            {
                var noRemuLiquidacions = new NoRemuneracionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoNoRemuneracion = noRemu.CodigoNoRemuneracion
                };

                totalNoRemunerativo += noRemu.Monto;

                _UnitOfWorkLiquidacion.NoRemuneracionLiquidacion.Insert(noRemuLiquidacions);
            }

            //confirmar liquidacion
            nuevaLiquidacion.TotalRemuneraciones = totalRemunerativo;
            nuevaLiquidacion.TotalNoRemunerativo = totalNoRemunerativo;
            nuevaLiquidacion.TotalDescuentos = totalDescuentos;
            nuevaLiquidacion.TotalRetenciones = totalRetenciones;

            _UnitOfWorkLiquidacion.LiquidacionRepository.Update(nuevaLiquidacion);
            _UnitOfWorkLiquidacion.Save();


            var pagos = new List<PagoLiquidacion>();

            Empleado empleado = this._Empleado ?? throw new NullReferenceException();

            var contrato = _ConsultarContrato.ConsultarContrato(nuevaLiquidacion.CodigoContrato);

            return _MapperLiquidacion.GenerarLiquidacionDTO(nuevaLiquidacion, remuneraciones,
                                                            retenciones, descuentos, noRemuneraciones, pagos, empleado,contrato);
        }

    }
}
