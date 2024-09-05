using LAUCHA.domain.entities.diasEspeciales;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IPeriodoVacacionesRepository
    {
        PeriodoVacaciones cargarNuevasVacaciones(PeriodoVacaciones vacaciones);
        List<PeriodoVacaciones> obtenerVacacionesEmpleado(string dniEmpleado, int anio);
        List<PeriodoVacaciones> obtenerVacacionesDelAnio(int anio);
    }
}
