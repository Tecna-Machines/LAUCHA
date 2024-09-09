using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;

namespace LAUCHA.application.UseCase.AgregarCuenta
{
    public class AgregarCuentaService : IAgregarCuentaService
    {
        private readonly IUnitOfWorkRetencionFijaCuenta _unitOfWorkRetencionFijaCuenta;
        private readonly IGenericRepository<Cuenta> _CuentaRepository;
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly IGenericRepository<RetencionFija> _RetencionFijaRepository;
        private readonly IRetencionFijaPorCuentaRepository _RetencionFijaPorCuentaRepository;
        private readonly CuentaMapper _CuentaMapper;
        private readonly ILogsApp log;

        public AgregarCuentaService(IUnitOfWorkRetencionFijaCuenta unitOfWorkRetencionFijaCuenta,
                                    IGenericRepository<Cuenta> cuentaRepository,
                                    IGenericRepository<Empleado> empleadoRepository,
                                    IRetencionFijaPorCuentaRepository retencionFijaPorCuentaRepository,
                                    IGenericRepository<RetencionFija> retencionFijaRepository,
                                    ILogsApp log)
        {
            _unitOfWorkRetencionFijaCuenta = unitOfWorkRetencionFijaCuenta;
            _CuentaMapper = new CuentaMapper();
            _CuentaRepository = cuentaRepository;
            _EmpleadoRepository = empleadoRepository;
            _RetencionFijaPorCuentaRepository = retencionFijaPorCuentaRepository;
            _RetencionFijaRepository = retencionFijaRepository;
            this.log = log;
        }

        public CuentaDTO AgregarRetencionesFijas(string numeroCuenta, string[] codigosRetenciones)
        {
            log.LogInformation("se configuraran retenciones fijas para la cuenta: {cuenta}", numeroCuenta);

            foreach (string codigo in codigosRetenciones)
            {
                RetencionFijaPorCuenta nuevaRetencionCuenta = new();
                nuevaRetencionCuenta.CodigoRetencionFija = codigo;
                nuevaRetencionCuenta.NumeroCuenta = numeroCuenta;

                log.LogInformation("configurando retencion: {codigo}", codigo);

                _unitOfWorkRetencionFijaCuenta.RetencionFijaRepository.Insert(nuevaRetencionCuenta);
            }

            //confirma las retenciones de la cuenta
            log.LogInformation("confirmando configuracion de la cuenta");
            _unitOfWorkRetencionFijaCuenta.Save();
            return this.ConsularUnaCuenta(numeroCuenta);
        }

        public CuentaDTO ConsularUnaCuenta(string numeroCuenta)
        {

            log.LogInformation("se esta consultando la cuenta n: {cuenta}", numeroCuenta);

            Cuenta cuenta = _CuentaRepository.GetById(numeroCuenta);
            Empleado empleado = _EmpleadoRepository.GetById(cuenta.DniEmpleado);
            List<RetencionFijaPorCuenta> retencionesFijaPorCuenta = _RetencionFijaPorCuentaRepository.
                                                                    ObtenerRetencionesFijasDeUnaCuenta(numeroCuenta);

            List<RetencionFija> retenciones = new List<RetencionFija>();

            foreach (var retencionBuscar in retencionesFijaPorCuenta)
            {
                var retencionAgregar = _RetencionFijaRepository.GetById(retencionBuscar.CodigoRetencionFija);
                retenciones.Add(retencionAgregar);
            }

            return _CuentaMapper.GenerarCuentaDTO(cuenta, empleado, retenciones);
        }
    }
}
