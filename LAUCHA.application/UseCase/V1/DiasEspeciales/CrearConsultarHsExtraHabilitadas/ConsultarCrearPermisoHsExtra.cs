using LAUCHA.application.DTOs.DiasEspecialesDTOs.HabilitacionHsExtraDTO;
using LAUCHA.application.interfaces.V2.IDiasEspecialesServices;
using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.DiasEspeciales.CrearConsultarHsExtraHabilitadas
{
    public class ConsultarCrearPermisoHsExtra : ICrearConsultarHsExtraHabilitadas
    {
        private readonly IHabilitacionHorasExtraRepository _hsExtraRepository;

        public ConsultarCrearPermisoHsExtra(IHabilitacionHorasExtraRepository hsExtraRepository)
        {
            _hsExtraRepository = hsExtraRepository;
        }

        public RespuestaHabilitacionHsExtraDTO crearPermisoHsExtra(CrearHabilitacionHsExtraDTO permiso)
        {
            var habilitacionHsExtra = new HabilitacionHorasExtra
            {
                DniEmpleado = permiso.DniEmpleado,
                DniResponsable = permiso.DniResponsable,
                FechaFin = permiso.FechaFin,
                FechaInicio = permiso.FechaInicio,
            };

            var habilitacion = _hsExtraRepository.cargarNuevaHabilitacionHsExtra(habilitacionHsExtra);

            return new RespuestaHabilitacionHsExtraDTO
            {
                DniEmpleado = habilitacion.DniEmpleado,
                DniResponsable = habilitacion.DniResponsable,
                FechaFin = habilitacion.FechaFin,
                FechaInicio = habilitacion.FechaInicio,
                NombreEmpleado = $"{habilitacion.Empleado.Nombre} {habilitacion.Empleado.Apellido}",
                NombreResponsable = $"{habilitacion.Responsable.Nombre}{habilitacion.Responsable.Nombre}"
            };
        }

        public List<RespuestaHabilitacionHsExtraDTO> verPermisoHsExtraPeriodoEmpleado(string dni,
                                                                                     DateTime fechaInicio,
                                                                                     DateTime fechaFin)
        {
            var habilitaciones = _hsExtraRepository.obtenerHabilitacionesEmpleadoPeriodo(dni,
                                                                                         fechaInicio,
                                                                                         fechaFin);

            var habilitacionesMapeadas = new List<RespuestaHabilitacionHsExtraDTO>();

            habilitaciones.ForEach(h =>
            {
                var aux = new RespuestaHabilitacionHsExtraDTO
                {
                    DniEmpleado = h.DniEmpleado,
                    DniResponsable = h.DniResponsable,
                    FechaFin = h.FechaFin,
                    FechaInicio = h.FechaInicio,
                    NombreEmpleado = $"{h.Empleado.Nombre} {h.Empleado.Apellido}",
                    NombreResponsable = $"{h.Responsable.Nombre}{h.Responsable.Nombre}"
                };

                habilitacionesMapeadas.Add(aux);
            });

            return habilitacionesMapeadas;
        }
    }
}
