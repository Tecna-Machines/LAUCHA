using LAUCHA.application.DTOs.LiquidacionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IConsultarLiquidacionService
    {
        LiquidacionDTO ConsulatarLiquidacion(string codigoLiquidacion);
    }
}
