namespace LAUCHA.domain.Entities.Creditos
{
    public interface ICreditoRepository
    {
        Task<Credito?> GetById(string id);
        Task<Credito> Insert(Credito credito);
        Task<Credito> Update(Credito credito);
        Task<IEnumerable<Credito>> GetAll();
        Task<IEnumerable<Credito>> GetByEmpleado(string dni);
        Task<IReadOnlyCollection<Credito>> Buscar(CreditoQuery query);
    }

    public sealed record CreditoQuery
    {
        public string? DniEmpleado { get; init; }
        public EstadoCredito? Estado { get; init; }

        public decimal? MontoMin { get; init; }
        public decimal? MontoMax { get; init; }

        public DateTime? CreacionDesde { get; init; }
        public DateTime? CreacionHasta { get; init; }

        public string? CodigoLiquidacion { get; set; }
    }
}
