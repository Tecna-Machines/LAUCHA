using LAUCHA.application.DTOs.DiasEspecialesDTOs.VacacionesDTO;
using LAUCHA.application.interfaces.V2.IDiasEspecialesServices;
using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V1.DiasEspeciales.CrearConsultarVacaciones
{
    public class CrearConsultarVacacionesService : ICrearConsultarVacacionesService
    {
        private readonly IPeriodoVacacionesRepository _periodoVacacionesRepository;

        public CrearConsultarVacacionesService(IPeriodoVacacionesRepository periodoVacacionesRepository)
        {
            _periodoVacacionesRepository = periodoVacacionesRepository;
        }

        public RespuestaVacacionesDTO crearNuevaVacacion(CrearVacacionesDTO vacaciones)
        {
            var periodo = new PeriodoVacaciones
            {
                DniEmpleado = vacaciones.DniEmpleado,
                FechaInicio = vacaciones.InicioVacaciones,
                FechaFin = vacaciones.FinVacaciones,
                Observacion = vacaciones.Observacion ?? "sin observacion"
            };

            var vacacionesCreadas = _periodoVacacionesRepository.cargarNuevasVacaciones(periodo);

            return new RespuestaVacacionesDTO
            {
                DniEmpleado = vacacionesCreadas.DniEmpleado,
                FinVacaciones = vacacionesCreadas.FechaFin,
                InicioVacaciones = vacacionesCreadas.FechaInicio,
                NombreEmpleado = $"{vacacionesCreadas.Empleado.Nombre} {vacacionesCreadas.Empleado.Apellido}",
                Observacion = vacacionesCreadas.Observacion
            };
        }

        public List<RespuestaVacacionesDTO> obtenerVacacionesAnio(int? anio)
        {
            var vacacionesMapear = _periodoVacacionesRepository.obtenerVacacionesDelAnio(anio ?? DateTime.Now.Year);

            var vacacionesMapeadas = new List<RespuestaVacacionesDTO>();

            vacacionesMapear.ForEach(v =>
            {
                var mapeo = new RespuestaVacacionesDTO
                {
                    DniEmpleado = v.DniEmpleado,
                    FinVacaciones = v.FechaFin,
                    InicioVacaciones = v.FechaInicio,
                    Observacion = v.Observacion,
                    NombreEmpleado = $"{v.Empleado.Nombre} {v.Empleado.Apellido}"
                };

                vacacionesMapeadas.Add(mapeo);
            });

            return vacacionesMapeadas;
        }

        public List<RespuestaVacacionesDTO> obtenerVacacionesEmpleado(string dni, int? anio)
        {
            var vacacionesMapeadas = new List<RespuestaVacacionesDTO>();
            var vacacionesMapea = _periodoVacacionesRepository
                                 .obtenerVacacionesEmpleado(dni, anio ?? DateTime.Now.Year);

            vacacionesMapea.ForEach(v =>
            {
                var mapeo = new RespuestaVacacionesDTO
                {
                    DniEmpleado = v.DniEmpleado,
                    FinVacaciones = v.FechaFin,
                    InicioVacaciones = v.FechaInicio,
                    Observacion = v.Observacion,
                    NombreEmpleado = $"{v.Empleado.Nombre} {v.Empleado.Apellido}"
                };

                vacacionesMapeadas.Add(mapeo);
            });

            return vacacionesMapeadas;
        }
    }
}
