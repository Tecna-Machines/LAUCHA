using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.DTOs.SueldosDTOs;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IEstrategiaCalcularSueldo
    {
        SueldosBrutosDTO CalcularSueldoBruto(ContratoDTO contrato);
        List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuentaConRetenciones);

    }
}
