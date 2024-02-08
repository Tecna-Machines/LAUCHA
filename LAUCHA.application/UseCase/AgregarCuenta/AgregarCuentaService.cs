using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AgregarCuentaService(IUnitOfWorkRetencionFijaCuenta unitOfWorkRetencionFijaCuenta,
                                    IGenericRepository<Cuenta> cuentaRepository,
                                    IGenericRepository<Empleado> empleadoRepository,
                                    IRetencionFijaPorCuentaRepository retencionFijaPorCuentaRepository,
                                    IGenericRepository<RetencionFija> retencionFijaRepository)
        {
            _unitOfWorkRetencionFijaCuenta = unitOfWorkRetencionFijaCuenta;
            _CuentaMapper = new CuentaMapper();
            _CuentaRepository = cuentaRepository;
            _EmpleadoRepository = empleadoRepository;
            _RetencionFijaPorCuentaRepository = retencionFijaPorCuentaRepository;
            _RetencionFijaRepository = retencionFijaRepository;
        }

        public CuentaDTO AgregarRetencionesFijas(string numeroCuenta,string[] codigosRetenciones)
        {
            foreach (string codigo in codigosRetenciones)
            {
                RetencionFijaPorCuenta nuevaRetencionCuenta = new();
                nuevaRetencionCuenta.CodigoRetencionFija = codigo;
                nuevaRetencionCuenta.NumeroCuenta = numeroCuenta;

                _unitOfWorkRetencionFijaCuenta.RetencionFijaRepository.Insert(nuevaRetencionCuenta);
            }

            //confirma las retenciones de la cuenta
            _unitOfWorkRetencionFijaCuenta.Save();
            return this.ConsularUnaCuenta(numeroCuenta);        
        }

        public CuentaDTO ConsularUnaCuenta(string numeroCuenta)
        {
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
