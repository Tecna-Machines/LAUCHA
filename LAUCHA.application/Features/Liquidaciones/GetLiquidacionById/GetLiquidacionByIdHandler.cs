using LAUCHA.application.Features.Acuerdos.GetAcuerdoById;
using LAUCHA.application.Mappers;
using LAUCHA.domain.Entities.Pagos;

namespace LAUCHA.application.Features.Liquidaciones.GetLiquidacionById
{
    internal class GetLiquidacionByIdHandler : IGetLiquidacionById
    {
        private readonly ILiquidacionRepository _liquidaciones;
        private readonly IEmpleadoRepository _empleados;
        private readonly IGetAcuerdoById _acuerdos;

        public GetLiquidacionByIdHandler(
            ILiquidacionRepository liquidaciones,
            IGetAcuerdoById acuerdos,
            IEmpleadoRepository empleados)
        {
            _liquidaciones = liquidaciones;
            _acuerdos = acuerdos;
            _empleados = empleados;
        }

        public async Task<Result<GetLiquidacionByIdResponse>> Get(string codigo)
        {
            var liquidacion = await _liquidaciones.GetById(codigo);

            if (liquidacion is null)
                return Result.Failure<GetLiquidacionByIdResponse>(LiquidacionErrors.NoExistente);

            var response = await MapLiquidacion(liquidacion);
            return Result.Success(response);
        }

        private async Task<GetLiquidacionByIdResponse> MapLiquidacion(Liquidacion liq)
        {
            var empleado = await _empleados.GetByDni(liq.DniEmpleado);
            var acuerdoResult = await _acuerdos.GetAcuerdo(new(liq.CodigoAcuerdo));

            var acuerdo = acuerdoResult.Value;

            return new GetLiquidacionByIdResponse(
                liq.Codigo,
                liq.FechaCreacion,
                liq.FechaSello,
                liq.EstaSellada(),
                liq.Concepto,
                MapQuincena(liq),
                MapEmpleado(empleado!),
                acuerdo,
                GenerarMontos(liq),
                MapItems(liq),
                MapPagos(liq));
        }

        private static QuincenaLiquidacion MapQuincena(Liquidacion liq)
            => new(liq.Anio, liq.Mes, liq.Quincena);

        private static EmpleadoLiquidacion MapEmpleado(Empleado emp)
            => new(emp.Dni,emp.Cuil, emp.Nombre, emp.Apellido, emp.FechaAlta, emp.FechaIngreso);

        private MontosPagar GenerarMontos(Liquidacion liq)
        => new(liq.CalcularNetoBlanco(), liq.CalcularNetoNegro());

        private IEnumerable<ItemLiquidacionByIdResponse> MapItems(Liquidacion liq)
        {
            List<ItemLiquidacionByIdResponse> ItemsResponse = new();

            foreach (var item in liq.GetAllItems())
            {
                var res = new ItemLiquidacionByIdResponse(item.Concepto,
                                                          item.NroItem,
                                                          (int)item.Estado,
                                                          item.Monto,
                                                          item.Fecha,
                                                          item.EsEnBlanco,
                                                          TipoItemLiquidacionMapper.ToInt(item.Tipo),
                                                          item.generadoPorUsuario);

                ItemsResponse.Add(res);
            }

            return ItemsResponse;
        }

        private IEnumerable<PagoLiquidacionById> MapPagos(Liquidacion liq)
        {
            var pagos = liq.Pagos;
            return pagos.Select(MapPago);
        }

        private PagoLiquidacionById MapPago(Pago p)
        => new(p.Id,
              p.Monto,
              p.Modo.ToString(),
              p.Fecha,
              p.Descripcion,
              p.ReferenciaContabilidad ?? "SIN PASAR");

    }
}
