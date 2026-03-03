using LAUCHA.domain.Entities.Feriados;

namespace LAUCHA.application.Features.Feriados.CrearFeriado
{
    internal class CrearFeriadoHandler : ICrearFeriado
    {
        private readonly IFeriadoRepository _feriados;

        public CrearFeriadoHandler(IFeriadoRepository feriados)
        {
            _feriados = feriados;
        }

        public async Task<Result<CrearFeriadoResponse>> Crear(CrearFeriadoRequest req)
        {
            var nuevoFeriado = new Feriado(req.Fecha, req.Descripcion);

            if (req.EsPermanente)
            {
                nuevoFeriado.MarcarComoPermanente();
            }

            try
            {
                await _feriados.Insert(nuevoFeriado);

            }
            catch (Exception ex)
            {
                return Result.Failure<CrearFeriadoResponse>(new Error(ex.Message));
            }

            var response = new CrearFeriadoResponse(req.Fecha, req.Descripcion, req.EsPermanente);

            return Result.Success(response);
        }
    }
}
