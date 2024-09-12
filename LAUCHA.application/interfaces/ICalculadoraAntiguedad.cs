using LAUCHA.application.DTOs.EmpleadoDTO;
using LAUCHA.domain.entities;

namespace LAUCHA.application.interfaces
{
    public interface ICalculadoraAntiguedad
    {
        Remuneracion CalcularAntiguedad(EmpleadoDTO empleado, decimal montoBrutoBlanco);
    }
}
