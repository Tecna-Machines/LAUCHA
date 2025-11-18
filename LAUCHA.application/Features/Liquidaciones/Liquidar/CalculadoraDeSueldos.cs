using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.application.Features.Liquidaciones.Liquidar
{
    public interface ICalculadoraDeSueldos
    {
        ICollection<ItemLiquidacion> CalcularItemsSueldo(Liquidacion liq, Acuerdo acu);
    }

}
