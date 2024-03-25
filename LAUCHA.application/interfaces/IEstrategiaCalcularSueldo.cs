using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.domain.entities;

namespace LAUCHA.application.interfaces
{
    public interface IEstrategiaCalcularSueldo
    {
        List<Remuneracion> CalcularSueldoBruto(DateTime desde, DateTime hasta, ContratoDTO contrato, CuentaDTO cuenta);
        List<Retencion> CalcularRetencionesSueldo(decimal montoBrutoBlanco, CuentaDTO cuentaConRetenciones);

    }
}
