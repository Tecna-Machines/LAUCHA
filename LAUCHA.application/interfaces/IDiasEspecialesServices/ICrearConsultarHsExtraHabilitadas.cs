using LAUCHA.application.DTOs.DiasEspecialesDTOs.HabilitacionHsExtraDTO;

namespace LAUCHA.application.interfaces.IDiasEspecialesServices
{
    public interface ICrearConsultarHsExtraHabilitadas
    {
        RespuestaHabilitacionHsExtraDTO crearPermisoHsExtra(CrearHabilitacionHsExtraDTO permiso);
        List<RespuestaHabilitacionHsExtraDTO> verPermisoHsExtraPeriodoEmpleado(string dni,
                                                                              DateTime fechaInicio
                                                                              , DateTime fechaFin);
    }
}
