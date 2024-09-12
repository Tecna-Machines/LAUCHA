using LAUCHA.application.DTOs.LiquidacionDTOs;

namespace LAUCHA.application.interfaces
{
    public interface ILiquidacionService
    {
        //public DeduccionDTOs HacerDeduccionesSueldo();
        //public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp);
        //Task<LiquidacionDTO> HacerUnaLiquidacion();
        Task<LiquidacionDTO> HacerUnaLiquidacion(string dni, PeriodoDTO periodo, bool esSimulacion);
    }
}
