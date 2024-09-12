using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Modulos.Modulo2
{
    public class ModuloRecuperadorItemsExistentes : IModuloLiquidador
    {
        private readonly IRemuneracionRepository _remuneracionRepository;
        private readonly IDescuentoRepository _descuentoRepository;
        private readonly INoRemuneracionRepository _noRemuneracionRepository;
        private readonly IRetencionRepository _retencionesReposity;

        public ModuloRecuperadorItemsExistentes(IRemuneracionRepository remuneracionRepository,
                                                IDescuentoRepository descuentoRepository,
                                                INoRemuneracionRepository noRemuneracionRepository,
                                                IRetencionRepository retencionesReposity)
        {
            _remuneracionRepository = remuneracionRepository;
            _descuentoRepository = descuentoRepository;
            _noRemuneracionRepository = noRemuneracionRepository;
            _retencionesReposity = retencionesReposity;
        }

        public async Task EjecutarRutina(LiquidacionPayload payload)
        {
            string numeroCuenta = payload.Cuenta.NumeroCuenta;
            PeriodoDTO periodo = payload.periodoliquidar;

            // Ejecutar todas las tareas asincrónicas en paralelo
            var obtenerRemuneracionesTask = this.ObtenerRemuneracionesExistentes(numeroCuenta, periodo);
            var obtenerDescuentosTask = this.ObtenerDescuentosPreexistentes(numeroCuenta, periodo);
            var obtenerNoRemuneracionesTask = this.ObtenerNoRemuneracionesPreexistentes(numeroCuenta, periodo);
            var obtenerRetencionesTask = this.ObtenerRetencionesPreexistentes(numeroCuenta, periodo);

            // Esperar que todas las tareas se completen
            await Task.WhenAll(obtenerRemuneracionesTask, obtenerDescuentosTask, obtenerNoRemuneracionesTask, obtenerRetencionesTask);

            // Asignar los resultados a las propiedades del payload
            payload.remuneracionesLiquidacion = await obtenerRemuneracionesTask ?? new List<Remuneracion>();
            payload.descuentosLiquidacion = await obtenerDescuentosTask ?? new List<Descuento>();
            payload.noRemuneracionesLiquidacion = await obtenerNoRemuneracionesTask ?? new List<NoRemuneracion>();
            payload.retencionesLiquidacion = await obtenerRetencionesTask ?? new List<Retencion>();
        
             payload.retencionesLiquidacion = obtenerRetencionesTask.Result ?? new List<Retencion>();
        }



        private async Task<List<Remuneracion>> ObtenerRemuneracionesExistentes(string numeroCuenta, PeriodoDTO periodo)
        {
            string orden = "DESC";

            var page = await _remuneracionRepository.ObtenerRemuneracionesFiltradas(
                                                                           numeroCuenta: numeroCuenta,
                                                                           desde: periodo.Inicio,
                                                                           hasta: periodo.Fin,
                                                                           orden: orden,
                                                                           descripcion: null,
                                                                           numeroPagina: 1,
                                                                           cantidadRegistros: 1000
                                                                           );

            return page.Registros;
        }

        private async Task<List<Descuento>> ObtenerDescuentosPreexistentes(string numeroCuenta, PeriodoDTO periodo)
        {
            var page = await _descuentoRepository.ObtenerDescuentosFiltrados(numeroCuenta: numeroCuenta,
                                                                             desde: periodo.Inicio,
                                                                             hasta: periodo.Fin,
                                                                             orden: "DESC",
                                                                             descripcion: null,
                                                                             numeroPagina: 1,
                                                                             cantidadRegistros: 1000);

            return page.Registros;
        }

        private async Task<List<NoRemuneracion>> ObtenerNoRemuneracionesPreexistentes(string numeroCuenta, PeriodoDTO periodo)
        {
            var page = await _noRemuneracionRepository.ObtenerNoRemuneracionesFiltradas(numeroCuenta: numeroCuenta,
                                                                             desde: periodo.Inicio,
                                                                             hasta: periodo.Fin,
                                                                             orden: "DESC",
                                                                             descripcion: null,
                                                                             numeroPagina: 1,
                                                                             cantidadRegistros: 1000);

            return page.Registros;
        }

        private async Task<List<Retencion>> ObtenerRetencionesPreexistentes(string numeroCuenta, PeriodoDTO periodo)
        {
            var page = await _retencionesReposity.ObtenerRetencionesFiltradas(numeroCuenta: numeroCuenta,
                                                                             desde: periodo.Inicio,
                                                                             hasta: periodo.Fin,
                                                                             orden: "DESC",
                                                                             descripcion: null,
                                                                             numeroPagina: 1,
                                                                             cantidadRegistros: 1000);

            return page.Registros;
        }
    }
}
