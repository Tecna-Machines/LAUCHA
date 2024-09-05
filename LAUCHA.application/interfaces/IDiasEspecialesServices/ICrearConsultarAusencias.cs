using LAUCHA.application.DTOs.DiasEspecialesDTOs.AusenciasDTO;

namespace LAUCHA.application.interfaces.IDiasEspecialesServices
{
    public interface ICrearConsultarAusencias
    {
        RespuestaAusenciaDTO crearAusencia(CrearAusenciaDTO ausencia);
        List<RespuestaAusenciaDTO> obtenerAusenciasEmpleado(string dni, int? anio);
    }
}
