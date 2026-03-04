using LAUCHA.domain.Entities.Feriados;

namespace LAUCHA.application.Features.Feriados.GetFeriadoMes
{
    internal class GetFeriadoMesHandler : IGetFeriadosMes
    {
        private readonly IFeriadoRepository _feriados;

        public GetFeriadoMesHandler(IFeriadoRepository feriados)
        {
            _feriados = feriados;
        }

        public async Task<Result<GetFeriadosMesResponse>> Get(int mes, int anio)
        {
            var feriados = await _feriados.GetFeriadosDelMes(mes, anio);

            var feriadosMap = feriados.Select(MapFeriado);

            return Result.Success(new GetFeriadosMesResponse(feriadosMap));
        }

        private GetFeriadoResponse MapFeriado(Feriado f)
                => new(f.Fecha, f.Descripcion, f.EsPermanente);
    }
}
