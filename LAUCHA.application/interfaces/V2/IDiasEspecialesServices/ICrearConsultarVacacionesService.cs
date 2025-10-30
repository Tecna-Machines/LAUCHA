using LAUCHA.application.DTOs.DiasEspecialesDTOs.VacacionesDTO;

namespace LAUCHA.application.interfaces.V2.IDiasEspecialesServices
{
    public interface ICrearConsultarVacacionesService
    {
        RespuestaVacacionesDTO crearNuevaVacacion(CrearVacacionesDTO vacaciones);
        List<RespuestaVacacionesDTO> obtenerVacacionesEmpleado(string dni, int? anio);
        List<RespuestaVacacionesDTO> obtenerVacacionesAnio(int? anio);
    }
}
