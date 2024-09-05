using LAUCHA.domain.entities.diasEspeciales;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IHabilitacionHorasExtraRepository
    {
        HabilitacionHorasExtra cargarNuevaHabilitacionHsExtra(HabilitacionHorasExtra habilitacion);
        List<HabilitacionHorasExtra> obtenerHabilitacionEmpleado(string dniEmpleado);
        List<HabilitacionHorasExtra> obtenerHabilitacionesEmpleadoPeriodo(string dniEmpleado,
                                                                     DateTime fechaInicio,
                                                                     DateTime fechaFin);
    }
}
