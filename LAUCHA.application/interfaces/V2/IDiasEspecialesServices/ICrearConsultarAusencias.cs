using LAUCHA.application.DTOs.DiasEspecialesDTOs.AusenciasDTO;

namespace LAUCHA.application.interfaces.V2.IDiasEspecialesServices
{
    public interface ICrearConsultarAusencias
    {
        RespuestaAusenciaDTO crearAusencia(CrearAusenciaDTO ausencia);
        List<RespuestaAusenciaDTO> obtenerAusenciasEmpleado(string dni, int? anio);
    }
}
