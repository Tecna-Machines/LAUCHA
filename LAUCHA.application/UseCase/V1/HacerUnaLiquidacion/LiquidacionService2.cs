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

        public DeduccionDTOs HacerDeduccionesSueldo()
        {
            throw new NotImplementedException();
        }

        public Task<LiquidacionDTO> HacerUnaLiquidacion()
        {
            throw new NotImplementedException();
        }

        public async Task<LiquidacionDTO> HacerUnaLiquidacion(string dni, PeriodoDTO periodo)
        {
            LiquidacionPayload payload = new();

            payload.Inicializar(dni,periodo,true);

            this.ProcesarLiquidacion(payload);

            return payload.ObtenerResultado() ?? throw new IOException();
        }

        private void ProcesarLiquidacion(LiquidacionPayload payload)
        {
            foreach (var modulo in _modulos)
            {
                Console.WriteLine("INICIO....................");
                modulo.EjecutarRutina(payload);
                payload.actualizarMontos();
                Console.WriteLine("TERMINO UN MODULO....................");

            }
        }

        public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp)
        {
            throw new NotImplementedException();
        }
    }
}
