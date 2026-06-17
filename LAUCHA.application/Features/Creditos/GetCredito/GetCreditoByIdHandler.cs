using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.GetCredito
{
    internal class GetCreditoByIdHandler : IGetCredito
    {
        private readonly ICreditoRepository _creditos;
        private readonly IEmpleadoRepository _empleados;

        public GetCreditoByIdHandler(ICreditoRepository creditos, IEmpleadoRepository empleados)
        {
            _creditos = creditos;
            _empleados = empleados;
        }

        public async Task<Result<GetCreditoByIdResponse>> Get(string codigo)
        {
            var credito = await _creditos.GetById(codigo);

            if (credito is null)
                return Result.Failure<GetCreditoByIdResponse>(Error.Null);

            var response = await MapCreditoResponse(credito);

            return Result.Success(response);
        }

        private async Task<GetCreditoByIdResponse> MapCreditoResponse(Credito credito)
        {
            var empleado = await _empleados.GetByDni(credito.DniEmpleado);
            var cuotasResponse = credito.Cuotas.Select(MapCuota).ToList();

            if (empleado is null)
                throw new ArgumentNullException("emplead.not.found");

            return new GetCreditoByIdResponse(credito.Codigo,
                                          credito.Descripcion,
                                          credito.Creacion,
                                          credito.ModoPago.ToString(),
                                          credito.DniEmpleado,
                                          empleado.GetFullName(),
                                          credito.MontoPrestado,
                                          credito.MontoDevolver,
                                          cuotasResponse);
        }

        private static CuotaResponse MapCuota(CuotaCredito c)
        {

            PagoCuota? pago = new PagoCuota(c.FechaPago, c.CodigoLiquidacion ?? "", 0);

            var quincena = new QuincenaCuota(c.QuincenaDebitar, c.MesDebitar, c.AnioDebitar);

            return new CuotaResponse(c.Nro.ToString(),
                                     c.Descripcion,
                                     c.Monto,
                                     c.Creacion,
                                     quincena,
                                     pago);
        }
    }
}
