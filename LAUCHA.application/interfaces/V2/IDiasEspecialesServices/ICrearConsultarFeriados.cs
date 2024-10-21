using LAUCHA.application.DTOs.DiasEspecialesDTOs.FeriadosDTO;

namespace LAUCHA.application.interfaces.V2.IDiasEspecialesServices
{
    public interface ICrearConsultarFeriados
    {
        RespuestaFeriado agregarFeriado(CrearFeriadoDTO feriado);
        List<RespuestaFeriado> obtenerFeriadosAnio(int? anio);
    }
}
