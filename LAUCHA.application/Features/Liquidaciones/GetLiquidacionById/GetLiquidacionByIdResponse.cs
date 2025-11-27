using LAUCHA.application.Features.Acuerdos.GetAcuerdoById;

namespace LAUCHA.application.Features.Liquidaciones.GetLiquidacionById
{
    public sealed record GetLiquidacionByIdResponse(string Codigo,
                                                   DateTime Creacion,
                                                   DateTime FechaSello,
                                                   bool SeSello,
                                                   string Concepto,
                                                   QuincenaLiquidacion Quincena,
                                                   EmpleadoLiquidacion Empleado,
                                                   GetAcuerdoByIdResponse Acuerdo,
                                                   MontosPagar Montos,
                                                   IEnumerable<ItemLiquidacionByIdResponse> Items,
                                                   IEnumerable<PagoLiquidacionById> Pagos);
    public sealed record QuincenaLiquidacion(int Anio, int Mes, int Nro);
    public sealed record EmpleadoLiquidacion(string Dni,
                                             string Nombre,
                                             string Apellido,
                                             DateTime FechaAlta,
                                             DateTime FechaIngreso);

    public sealed record MontosPagar(decimal EnBlanco, decimal EnNegro);
    public sealed record ItemLiquidacionByIdResponse(string Concepto,
                                                     decimal Monto,
                                                     DateTime Fecha,
                                                     bool EsEnBlanco,
                                                     int TipoItem,
                                                     bool EsAutomatico);

    //TODO: para la futura logica de pagos
    public sealed record PagoLiquidacionById();
}
