using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface ILiquidacionService
    {
        public DeduccionDTOs HacerDeduccionesSueldo();
        public void SetearEmpleadoALiquidar(ContratoDTO contratoEmp, CuentaDTO cuentaEmp);
    }
}
