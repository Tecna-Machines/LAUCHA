using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.ConsultarLiquidacion
{
    public class ConsularLiquidacionService : IConsultarLiquidacionService
    {
        private readonly LiquidacionMapper _MapperLiquidacion;
        private readonly IItemsLiquidacionRepository _ItemsLiquidacionRepository;
        private readonly IGenericRepository<LiquidacionPersonal> _LiquidacionRepository;
        private readonly IGenericRepository<Cuenta> _CuentaRepository;
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;

        public ConsularLiquidacionService(IGenericRepository<LiquidacionPersonal> liquidacionRepository,
                                          IItemsLiquidacionRepository itemsLiquidacionRepository,
                                          IGenericRepository<Cuenta> cuentaRepository,
                                          IGenericRepository<Empleado> empleadoRepository)
        {
            _MapperLiquidacion = new();
            _LiquidacionRepository = liquidacionRepository;
            _ItemsLiquidacionRepository = itemsLiquidacionRepository;
            _CuentaRepository = cuentaRepository;
            _EmpleadoRepository = empleadoRepository;
        }

        public LiquidacionDTO ConsulatarLiquidacion(string codigoLiquidacion)
        {
            LiquidacionPersonal liquidacion = _LiquidacionRepository.GetById(codigoLiquidacion);

            List<Retencion> retenciones = _ItemsLiquidacionRepository.ObtenerRetencionesLiquidacion(codigoLiquidacion);
            List<Remuneracion> remuneraciones = _ItemsLiquidacionRepository.ObtenerRemuneracionesLiquidacion(codigoLiquidacion);
            List<Descuento> descuentos = _ItemsLiquidacionRepository.ObtenerDescuentosLiquidacion(codigoLiquidacion);
            List<NoRemuneracion> noRemuneraciones = _ItemsLiquidacionRepository.ObtenerNoRemuneracionesLiquidacion(codigoLiquidacion);

            List<PagoLiquidacion> pagos = _ItemsLiquidacionRepository.ObtenerPagosLiquidacion(codigoLiquidacion);

            string numeroCuenta = retenciones[0].NumeroCuenta;

            Cuenta cuenta = _CuentaRepository.GetById(numeroCuenta);
            Empleado empleado = _EmpleadoRepository.GetById(cuenta.DniEmpleado);

            return _MapperLiquidacion.GenerarLiquidacionDTO(liquidacion,remuneraciones,retenciones,descuentos,noRemuneraciones,pagos,empleado);
        }
    }
}
