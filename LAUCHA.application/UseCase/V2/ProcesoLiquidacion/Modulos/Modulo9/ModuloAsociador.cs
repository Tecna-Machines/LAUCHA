using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.Mappers;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IUnitsOfWork;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo9
{
    public class ModuloAsociador : IModuloLiquidador
    {
        private readonly IUnitOfWorkLiquidacion _unitOfWorkLiquidacion;

        public ModuloAsociador(IUnitOfWorkLiquidacion unitOfWorkLiquidacion)
        {
            _unitOfWorkLiquidacion = unitOfWorkLiquidacion;
        }

        public async Task EjecutarRutina(LiquidacionPayload payload)
        {
            var liquidacion = this.InicializarLiquidacion(payload);
            string codigo = liquidacion.CodigoLiquidacion;

            if (!payload.esSimulacion)
            {
                this.AsociarRemuneraciones(codigo, payload.remuneracionesLiquidacion);
                this.AsociarNoRemuneraciones(codigo, payload.noRemuneracionesLiquidacion);
                this.AsociarRetenciones(codigo, payload.retencionesLiquidacion);
                this.AsociarDescuentos(codigo, payload.descuentosLiquidacion);

                this.guardarCambios();
            }

            var resultado = this.GenerarResultado(payload,liquidacion);
            payload.SetResultado(resultado);

        }

        private LiquidacionPersonal InicializarLiquidacion(LiquidacionPayload payload)
        {
            LiquidacionPersonal liquidacion = new();

            liquidacion.CodigoLiquidacion = this.CrearCodigoLiquidacion(payload.Empleado.Dni);
            liquidacion.CodigoContrato = payload.Contrato.Codigo;
            liquidacion.Concepto = $"liquidacion ,{payload.Empleado.Nombre} {payload.Empleado.Apellido}";
            liquidacion.InicioPeriodo = payload.periodoliquidar.Inicio;
            liquidacion.FinPeriodo = payload.periodoliquidar.Fin;
            liquidacion.FechaLiquidacion = DateTime.Now;

            _unitOfWorkLiquidacion.LiquidacionRepository.Insert(liquidacion);

            return liquidacion;
        }

        private string CrearCodigoLiquidacion(string dniEmpleado)
        {
            DateTime fechaActual = DateTime.Now;

            int numeroQuincena = fechaActual.Day < 15 ? 1 : 2;

            return $"{fechaActual.Year}{fechaActual.Month}{numeroQuincena}-{dniEmpleado}";
        }

        private void AsociarRemuneraciones(string codigoLiquidacion, List<Remuneracion> remuneraciones)
        {
            foreach (var remu in remuneraciones)
            {

                _unitOfWorkLiquidacion.RemuneracionRepository.Insert(remu);

                var remuLiquidacion = new RemuneracionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = codigoLiquidacion,
                    CodigoRemuneracion = remu.CodigoRemuneracion
                };


                _unitOfWorkLiquidacion.RemuneracionLiquidacion.Insert(remuLiquidacion);
            }
        }

        private void AsociarNoRemuneraciones(string codigoLiquidacion, List<NoRemuneracion> noRemuneraciones)
        {
            foreach (var noRemu in noRemuneraciones)
            {

                _unitOfWorkLiquidacion.NORemuneracionRepository.Insert(noRemu);

                var noRemuLiquidacions = new NoRemuneracionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = codigoLiquidacion,
                    CodigoNoRemuneracion = noRemu.CodigoNoRemuneracion
                };

                _unitOfWorkLiquidacion.NoRemuneracionLiquidacion.Insert(noRemuLiquidacions);
            }
        }

        private void AsociarDescuentos(string codigoLiquidacion, List<Descuento> descuentos)
        {
            foreach (var desc in descuentos)
            {
                _unitOfWorkLiquidacion.DescuentoRepository.Insert(desc);

                var desLiquidacion = new DescuentoPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = codigoLiquidacion,
                    CodigoDescuento = desc.CodigoDescuento
                };

                _unitOfWorkLiquidacion.DescuentoLiquidacion.Insert(desLiquidacion);
            }
        }

        private void AsociarRetenciones(string codigoLiquidacion, List<Retencion> retenciones)
        {
            foreach (var reten in retenciones)
            {
                _unitOfWorkLiquidacion.RetencionRepository.Insert(reten);

                var retenLiquidacion = new RetencionPorLiquidacionPersonal
                {
                    CodigoLiquidacionPersonal = codigoLiquidacion,
                    CodigoRetencion = reten.CodigoRetencion
                };

                _unitOfWorkLiquidacion.RetencionLiquidacion.Insert(retenLiquidacion);
            }
        }

        private int guardarCambios()
        {
            return _unitOfWorkLiquidacion.Save();
        }


        private LiquidacionDTO GenerarResultado(LiquidacionPayload payload,LiquidacionPersonal liquidacion)
        {
            LiquidacionMapper mappper = new();
            EmpleadoMapper empMapper = new();

            var empleado = empMapper.GenerarEmpleado(payload.Empleado);


            return mappper.GenerarLiquidacionDTO(liquidacion: liquidacion,
                                                  remuneraciones: payload.remuneracionesLiquidacion,
                                                  retenciones: payload.retencionesLiquidacion,
                                                  descuentos: payload.descuentosLiquidacion,
                                                  noRemuneraciones: payload.noRemuneracionesLiquidacion,
                                                  empleado: empleado,
                                                  pagos: new List<PagoLiquidacion>(),
                                                  contratoDTO: payload.Contrato

                );
        }
    }
}
