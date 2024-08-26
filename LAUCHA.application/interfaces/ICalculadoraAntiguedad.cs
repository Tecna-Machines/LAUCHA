using LAUCHA.domain.entities;

namespace LAUCHA.application.interfaces
{
    public interface ICalculadoraAntiguedad
    {
        Remuneracion CalcularAntiguedad(Empleado empleado, decimal montoBrutoBlanco);
    }
}
