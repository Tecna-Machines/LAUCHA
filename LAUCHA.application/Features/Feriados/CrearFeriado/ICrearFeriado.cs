namespace LAUCHA.application.Features.Feriados.CrearFeriado
{
    public interface ICrearFeriado
    {
        Task<Result<CrearFeriadoResponse>> Crear(CrearFeriadoRequest req);
    }
}
