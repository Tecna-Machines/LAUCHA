using LAUCHA.application.DTOs.ContratoDTO;
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
        private readonly IGenericRepository<Cuenta> _CuentaRepository;
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly IRemuneracionRepository _RemuneracionRepositoryEspecifico;
        private readonly IRetencionRepository _RetencionRepositoryEspecifico;
        private readonly IDescuentoRepository _DescuentoRepositoryEspecifo;
        private readonly INoRemuneracionRepository _NoRemuneracionRepositoryEspecifico;

        private readonly IUnitOfWorkLiquidacion _UnitOfWorkLiquidacion;

        private RemuneracionMapper _MapperRemuneracion;
        private RetencionMapper _MapperRetenciones;
        private LiquidacionMapper _MapperLiquidacion;


        private ContratoDTO? _Contrato;
        private CuentaDTO? _Cuenta;

        private DateTime _InicioPeriodo;
        private DateTime _FinPeriodo;

        public CrearLiquidacionService(IFabricaCalculadoraSueldo fabricaCalculadora,
                                       IUnitOfWorkLiquidacion unitOfWorkLiquidacion,
                                       IRemuneracionRepository remuneracionRepositoryEspecifico,
                                       IRetencionRepository retencionRepositoryEspecifico,
                                       IDescuentoRepository descuentoRepositoryEspecifo,
                                       IGenericRepository<Cuenta> cuentaRepository,
                                       IGenericRepository<Empleado> empleadoRepository,
                                       INoRemuneracionRepository noRemuneracionRepositoryEspecifico)
        {
            _MapperRemuneracion = new();
            _MapperRetenciones = new();
            _MapperLiquidacion = new();

            _FabricaCalculadora = fabricaCalculadora;
            _UnitOfWorkLiquidacion = unitOfWorkLiquidacion;
            _RemuneracionRepositoryEspecifico = remuneracionRepositoryEspecifico;
            _RetencionRepositoryEspecifico = retencionRepositoryEspecifico;
            _DescuentoRepositoryEspecifo = descuentoRepositoryEspecifo;
            _CuentaRepository = cuentaRepository;
            _EmpleadoRepository = empleadoRepository;
            _NoRemuneracionRepositoryEspecifico = noRemuneracionRepositoryEspecifico;
        }

        public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp)
        {
            TimeSpan diferencionFechas = finPeriodo - inicioPeriodo;
            int diasPeriodo = diferencionFechas.Days;

            if(diasPeriodo>31)
            {
                throw new PeriodoExcepcion("el periodo no puede ser mayor a 31 dias");
            }

            if (inicioPeriodo > finPeriodo)
            {
                throw new PeriodoExcepcion("el inicio de periodo  es menor que el fin del periodo");
            }

            if (inicioPeriodo == finPeriodo)
            {
                throw new PeriodoExcepcion("no pueden utilizarse las mismas fechas para liquidar");
            }

            _Contrato = contratoEmp;
            _Cuenta = cuentaEmp;

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

            var remuneracionesSueldo = _CalculadoraSueldo.CalcularSueldoBruto(this._InicioPeriodo, this._FinPeriodo, _Contrato!, _Cuenta!);

            if (remuneracionesSueldo.Count < 1)
            {
                throw new SueldoException("no se pudieron calcular remuneraciones");
            }

            foreach (var remuneracionNueva in remuneracionesSueldo)
            {
                if (remuneracionNueva.EsBlanco) { montoBrutoBlanco = +remuneracionNueva.Monto; }

                _UnitOfWorkLiquidacion.RemuneracionRepository.Insert(remuneracionNueva);

                var remuneracionDTO = _MapperRemuneracion.GenerarRemuneracionDTO(remuneracionNueva);
                remuneracionesDTO.Add(remuneracionDTO);
            }



            var retenciones = _CalculadoraSueldo.CalcularRetencionesSueldo(montoBrutoBlanco, _Cuenta!);

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
                Remuneraciones = remuneracionesDTO,
                Retenciones = retencionesDTO
            };
        }

        public async Task<LiquidacionDTO> HacerUnaLiquidacion()
        {
            DateTime fechaActual = DateTime.Now;

            int numeroQuincena = fechaActual.Day < 15 ? 1 : 2;
            string leyendaLiquidacion = fechaActual.Day < 15 ? "1ra QUINCENA" : "2da QUINCENA";

            string codigoNuevaLiquidacion = $"{fechaActual.Year}{fechaActual.Month + 1}{numeroQuincena}-{_Contrato?.Dni}";

            LiquidacionPersonal nuevaLiquidacion = new()
            {
                CodigoLiquidacion = codigoNuevaLiquidacion,
                Concepto = $"LIQUIDACION SUELDO: {leyendaLiquidacion} | {_Cuenta?.Empleado}",
                InicioPeriodo = _InicioPeriodo,
                FinPeriodo = _FinPeriodo,
                FechaLiquidacion = fechaActual

            };

            //insertar liquidacion
            _UnitOfWorkLiquidacion.LiquidacionRepository.Insert(nuevaLiquidacion);

            //logica para traer remuneracion , retenciones y descuentos para crear la liquidacion
            List<Remuneracion> remuneraciones = await ObtenerRemuneracionesParaLiquidacion();
            List<Retencion> retenciones = await ObtenerRetencionesParaLiquidacion();
            List<Descuento> descuentos = await ObtenerDescuentosParaLiquidacion();
            List<NoRemuneracion> noRemuneraciones = await ObtenerNoRemunerativoParaLiquidacion();


            foreach (var remu in remuneraciones)
            {
                var remuLiquidacion = new RemuneracionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoRemuneracion = remu.CodigoRemuneracion
                };

                _UnitOfWorkLiquidacion.RemuneracionLiquidacion.Insert(remuLiquidacion);
            }

            foreach (var reten in retenciones)
            {
                var retenLiquidacion = new RetencionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoRetencion = reten.CodigoRetencion
                };

                _UnitOfWorkLiquidacion.RetencionLiquidacion.Insert(retenLiquidacion);
            }

            foreach (var desc in descuentos)
            {
                var desLiquidacion = new DescuentoPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoDescuento = desc.CodigoDescuento
                };

                _UnitOfWorkLiquidacion.DescuentoLiquidacion.Insert(desLiquidacion);
            }

            foreach(var noRemu in noRemuneraciones)
            {
                var noRemuLiquidacions = new NoRemuneracionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = nuevaLiquidacion.CodigoLiquidacion,
                    CodigoNoRemuneracion = noRemu.CodigoNoRemuneracion
                };

                _UnitOfWorkLiquidacion.NoRemuneracionLiquidacion.Insert(noRemuLiquidacions);
            }

            //confirmar liquidacion
            _UnitOfWorkLiquidacion.Save();


            var pagos = new List<PagoLiquidacion>(); //pagos falseos

            //buscamos al empleado usando la cuenta (no es lo idea pero bueno :/ )
            Cuenta cuenta = _CuentaRepository.GetById(this._Cuenta!.NumeroCuenta);
            Empleado empleado = _EmpleadoRepository.GetById(cuenta.DniEmpleado);


            return _MapperLiquidacion.GenerarLiquidacionDTO(nuevaLiquidacion,remuneraciones,
                                                            retenciones,descuentos,noRemuneraciones,pagos,empleado);
        }


        private async Task<List<Remuneracion>> ObtenerRemuneracionesParaLiquidacion()
        {
            var remuneraciones = await _RemuneracionRepositoryEspecifico.
                      ObtenerRemuneracionesFiltradas(_Cuenta?.NumeroCuenta, _InicioPeriodo, _FinPeriodo, null, null, 1, 1000);

            return remuneraciones.Registros;
        }

        private async Task<List<Retencion>> ObtenerRetencionesParaLiquidacion()
        {
            var retenciones = await _RetencionRepositoryEspecifico.
                      ObtenerRetencionesFiltradas(_Cuenta?.NumeroCuenta, _InicioPeriodo, _FinPeriodo, null, null, 1, 1000);

            return retenciones.Registros;
        }

        private async Task<List<Descuento>> ObtenerDescuentosParaLiquidacion()
        {
            var descuentos = await _DescuentoRepositoryEspecifo.
                      ObtenerDescuentosFiltrados(_Cuenta?.NumeroCuenta, _InicioPeriodo, _FinPeriodo, null, null, 1, 1000);

            return descuentos.Registros;
        }

        private async Task<List<NoRemuneracion>> ObtenerNoRemunerativoParaLiquidacion()
        {
            var noRemuneraciones = await _NoRemuneracionRepositoryEspecifico.
                ObtenerNoRemuneracionesFiltradas(_Cuenta?.NumeroCuenta, _InicioPeriodo, _FinPeriodo, null, null, 1, 1000);

            return noRemuneraciones.Registros;
        }

    }
}
