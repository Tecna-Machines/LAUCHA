using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.UseCase.V2.ProcesoLiquidacion.Models;

namespace LAUCHA.application.interfaces
{
    public interface ILiquidacionService
    {
        public DeduccionDTOs HacerDeduccionesSueldo();
        public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp);
        Task<LiquidacionDTO> HacerUnaLiquidacion();
        Task<LiquidacionDTO> HacerUnaLiquidacion(string dni,PeriodoDTO periodo);
    }
}
