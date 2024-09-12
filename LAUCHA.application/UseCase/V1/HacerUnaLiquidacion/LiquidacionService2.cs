using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Interfaces;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;

namespace LAUCHA.application.UseCase.V1.HacerUnaLiquidacion
{
    public class LiquidacionService2 : ILiquidacionService
    {
        private readonly IEnumerable<IModuloLiquidador> _modulos;
        private readonly IConsultarLiquidacionService _consultarLiquidacion;

        public LiquidacionService2(IEnumerable<IModuloLiquidador> modulos,
                                   IConsultarLiquidacionService consultarLiquidacion)
        {
            _modulos = modulos;
            _consultarLiquidacion = consultarLiquidacion;
        }


        public async Task<LiquidacionDTO> HacerUnaLiquidacion(string dni, PeriodoDTO periodo, bool esSimulacion)
        {
            LiquidacionPayload payload = new();

            payload.Inicializar(dni,periodo,esSimulacion);

            await this.ProcesarLiquidacion(payload);

            return payload.ObtenerResultado() ?? throw new IOException();
        }

        private async Task ProcesarLiquidacion(LiquidacionPayload payload)
        {
            foreach (var modulo in _modulos)
            {
                await modulo.EjecutarRutina(payload);
                payload.actualizarMontos();
            }
        }

        public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp)
        {
            throw new NotImplementedException();
        }
    }
}
