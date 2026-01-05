namespace LAUCHA.application.Features.Creditos.GetCreditos
{
    public interface IGetCreditos
    {
        Task<Result<GetCreditos>> GetCreditos(FiltroCredito filtro);
    }

    public sealed record FiltroCredito
    {
        public string? Dni { get; init; }
        public int? Estado { get; init; }

        public decimal? MontoMin { get; init; }
        public decimal? MontoMax { get; init; }

        public DateTime? CreacionDesde { get; init; }
        public DateTime? CreacionHasta { get; init; }
    }
}
