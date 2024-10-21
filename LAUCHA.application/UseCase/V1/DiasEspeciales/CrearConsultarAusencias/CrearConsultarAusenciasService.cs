using LAUCHA.application.DTOs.DiasEspecialesDTOs.AusenciasDTO;
using LAUCHA.application.interfaces.V2.IDiasEspecialesServices;
using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.DiasEspeciales.CrearConsultarAusencias
{
    public class CrearConsultarAusenciasService : ICrearConsultarAusencias
    {
        private readonly IAvisoAusenciaRepository _ausenciasRepository;

        public CrearConsultarAusenciasService(IAvisoAusenciaRepository ausenciasRepository)
        {
            _ausenciasRepository = ausenciasRepository;
        }

        public RespuestaAusenciaDTO crearAusencia(CrearAusenciaDTO ausencia)
        {
            var aviso = new AvisosAusencia
            {
                DniEmpleado = ausencia.DniEmpleado,
                FechaAusencia = ausencia.FechaAusencia,
                FechaCreacionAviso = DateTime.Now,
                Motivo = ausencia.Motivo
            };

            var avisoCreado = _ausenciasRepository.cargarAvisoAusencia(aviso);

            return new RespuestaAusenciaDTO
            {
                DniEmpleado = avisoCreado.DniEmpleado,
                FechaAusencia = aviso.FechaAusencia,
                FechaCreacion = aviso.FechaCreacionAviso,
                Motivo = aviso.Motivo
            };
        }

        public List<RespuestaAusenciaDTO> obtenerAusenciasEmpleado(string dni, int? anio)
        {
            var avisos = _ausenciasRepository.obtenerAvisoAusenciaEmpleadoEnAnio(dni, anio ?? DateTime.Now.Year);
            var avisosMapeados = new List<RespuestaAusenciaDTO>();

            avisos.ForEach(av =>
            {
                var aux = new RespuestaAusenciaDTO
                {
                    DniEmpleado = av.DniEmpleado,
                    FechaAusencia = av.FechaAusencia,
                    FechaCreacion = av.FechaCreacionAviso,
                    Motivo = av.Motivo
                };

                avisosMapeados.Add(aux);
            });

            return avisosMapeados;
        }
    }
}
