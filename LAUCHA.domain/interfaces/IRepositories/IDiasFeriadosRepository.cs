using LAUCHA.domain.entities.diasEspeciales;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IDiasFeriadosRepository
    {
        List<DiaFeriado> obtenerFeriadosAnio(int anio);
        DiaFeriado cargarFeriado(DiaFeriado feriado);
    }
}
