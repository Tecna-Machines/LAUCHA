using LAUCHA.application.DTOs.DiasEspecialesDTOs.HabilitacionHsExtraDTO;

namespace LAUCHA.application.interfaces.V2.IDiasEspecialesServices
{
    public interface ICrearConsultarHsExtraHabilitadas
    {
        RespuestaHabilitacionHsExtraDTO crearPermisoHsExtra(CrearHabilitacionHsExtraDTO permiso);
        List<RespuestaHabilitacionHsExtraDTO> verPermisoHsExtraPeriodoEmpleado(string dni,
                                                                              DateTime fechaInicio
                                                                              , DateTime fechaFin);
    }
}
