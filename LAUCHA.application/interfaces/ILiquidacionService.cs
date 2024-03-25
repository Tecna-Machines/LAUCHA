using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;

namespace LAUCHA.application.interfaces
{
    public interface ILiquidacionService
    {
        public DeduccionDTOs HacerDeduccionesSueldo();
        public void SetearEmpleadoALiquidar(DateTime inicioPeriodo, DateTime finPeriodo, ContratoDTO contratoEmp, CuentaDTO cuentaEmp);
        Task<LiquidacionDTO> HacerUnaLiquidacion();
    }
}
