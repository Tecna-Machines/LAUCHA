using LAUCHA.domain.Entities.Creditos;

namespace LAUCHA.application.Features.Creditos.GetCredito
{
    internal class GetCreditoHandler : IGetCredito
    {
        private readonly ICreditoRepository _creditos;
        private readonly IEmpleadoRepository _empleados;

        public GetCreditoHandler(ICreditoRepository creditos, IEmpleadoRepository empleados)
        {
            _creditos = creditos;
            _empleados = empleados;
        }

        public async Task<Result<GetCreditoResponse>> Get(string codigo)
        {
            var credito = await _creditos.GetById(codigo);

            if (credito is null)
                return Result.Failure<GetCreditoResponse>(Error.Null);

            var response = await MapCreditoResponse(credito);

            return Result.Success(response);
        }

        private async Task<GetCreditoResponse> MapCreditoResponse(Credito credito)
        {
           var empleado = await _empleados.GetByDni(credito.DniEmpleado);
           var cuotasResponse = credito.Cuotas.Select(MapCuota).ToList();

            if (empleado is null)
                throw new ArgumentNullException("emplead.not.found");

            return new GetCreditoResponse(credito.Codigo,
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

            PagoCuota? pago = new PagoCuota(c.FechaPago,c.CodigoLiquidacion ?? "",c.NroItem ?? -1);

            if (c.CodigoLiquidacion is null)
                    pago = null;

            var quincena = new QuincenaCuota(c.QuincenaDebitar,c.MesDebitar,c.AnioDebitar);

            return new CuotaResponse(c.Nro.ToString(),
                                     c.Descripcion,
                                     c.Monto,
                                     c.Creacion,
                                     quincena,
                                     pago);
        }
    }
}
