using LAUCHA.domain.entities.diasEspeciales;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IAvisoAusenciaRepository
    {
        AvisosAusencia cargarAvisoAusencia(AvisosAusencia aviso);
        List<AvisosAusencia> obtenerAvisoAusenciaEmpleadoEnAnio(string dniEmpleado, int anio);
    }
}
