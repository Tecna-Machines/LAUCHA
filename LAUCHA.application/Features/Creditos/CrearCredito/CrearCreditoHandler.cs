using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.CrearCredito
{
    internal class CrearCreditoHandler : ICrearCredito
    {
        private readonly IFabricaDeCuotas _fabricaCuotas;
        private readonly ICreditoRepository _creditos;

        public CrearCreditoHandler(IFabricaDeCuotas fabricaCuotas, ICreditoRepository creditos)
        {
            _fabricaCuotas = fabricaCuotas;
            _creditos = creditos;
        }

        public async Task<Result<CrearCreditoResponse>> Crear(CrearCreditoRequest req)
        {

            var opciones = MapOpciones(req);
            var credito = Credito.CrearSinCuotas(opciones);

            var cuotas = _fabricaCuotas.Fabricar(credito, req.Quincena);

            credito.AgregarCuotas(cuotas);

            await _creditos.Insert(credito);

            var response = new CrearCreditoResponse(credito.Codigo, credito.Descripcion);

            return Result.Success(response);
        }

        private OpcionesCredito MapOpciones(CrearCreditoRequest req) => new(
            req.Dni,
            req.MontoPrestado,
            req.MontoDevolver,
            req.Descripcion,
            (ModoPagoCredito)req.ModoPago,
            req.CantidadCuotas
         );

    }
}
