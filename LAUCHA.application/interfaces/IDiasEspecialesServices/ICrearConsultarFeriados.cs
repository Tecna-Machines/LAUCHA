using LAUCHA.application.DTOs.DiasEspecialesDTOs.FeriadosDTO;

namespace LAUCHA.application.interfaces.IDiasEspecialesServices
{
    public interface ICrearConsultarFeriados
    {
        RespuestaFeriado agregarFeriado(CrearFeriadoDTO feriado);
        List<RespuestaFeriado> obtenerFeriadosAnio(int? anio);
    }
}
