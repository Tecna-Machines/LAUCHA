using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.GetCreditos
{
    internal class GetCreditosHandler : IGetCreditos
    {
        private readonly ICreditoRepository _creditos;

        public GetCreditosHandler(ICreditoRepository creditos)
        {
            _creditos = creditos;
        }

        public async Task<Result<GetCreditos>> GetCreditos(FiltroCredito filtro)
        {
            var query = MapQuery(filtro);

            var creditos = await _creditos.Buscar(query);
            var creditosResumidos = creditos.Select(MapResumen).ToList();

            var response = new GetCreditos(creditosResumidos);

            return Result.Success(response);
        }

        public static CreditoQuery MapQuery(FiltroCredito f)
        {
            return new CreditoQuery
            {
                DniEmpleado = string.IsNullOrWhiteSpace(f.Dni) ? null : f.Dni,

                Estado = MapEstado(f.Estado),

                MontoMin = f.MontoMin,
                MontoMax = f.MontoMax,

                CreacionDesde = f.CreacionDesde,
                CreacionHasta = f.CreacionHasta
            };
        }

        private static EstadoCredito? MapEstado(int? estado)
        {
            if (!estado.HasValue) return null;

            if (!Enum.IsDefined(typeof(EstadoCredito), estado.Value))
                throw new ArgumentException($"Error.estado: {estado.Value}");

            return (EstadoCredito)estado.Value;
        }

        private static GetCreditoResumen MapResumen(Credito c) =>
            new(c.Codigo,
                c.DniEmpleado,
                c.CantidadCuotas,
                c.MontoPrestado,
                c.Estado.ToString());
    }
}
