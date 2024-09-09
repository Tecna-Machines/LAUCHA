using LAUCHA.application.DTOs.DiasEspecialesDTOs.FeriadosDTO;
using LAUCHA.application.interfaces.IDiasEspecialesServices;
using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.DiasEspeciales.CrearConsultarFeriados
{
    public class CrearConsultarFeriado : ICrearConsultarFeriados
    {
        private readonly IDiasFeriadosRepository _diasFeriadosRepository;

        public CrearConsultarFeriado(IDiasFeriadosRepository diasFeriadosRepository)
        {
            _diasFeriadosRepository = diasFeriadosRepository;
        }

        public RespuestaFeriado agregarFeriado(CrearFeriadoDTO feriado)
        {
            var feriadoMapeado = new DiaFeriado
            {
                FechaFeriado = feriado.FechaFeriado,
                FechaCreacion = DateTime.Now,
                Descripcion = feriado.DescripcionFeriado
            };

            var feriadoCreado = _diasFeriadosRepository.cargarFeriado(feriadoMapeado);

            return new RespuestaFeriado
            {
                DescripcionFeriado = feriadoCreado.Descripcion,
                FechaCreacion = feriadoCreado.FechaCreacion,
                FechaFeriado = feriadoCreado.FechaFeriado
            };
        }

        public List<RespuestaFeriado> obtenerFeriadosAnio(int? anio)
        {
            var feriadosObtenidos = _diasFeriadosRepository.obtenerFeriadosAnio(anio ?? DateTime.Now.Year);
            var feriadosMapeados = new List<RespuestaFeriado>();

            feriadosObtenidos.ForEach(f =>
            {
                var feriadoMap = new RespuestaFeriado
                {
                    FechaCreacion = f.FechaCreacion,
                    FechaFeriado = f.FechaFeriado,
                    DescripcionFeriado = f.Descripcion
                };

                feriadosMapeados.Add(feriadoMap);
            });

            return feriadosMapeados;
        }
    }
}
