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
                                                   IEnumerable<PagoLiquidacionById> Pagos)
    {
        public bool EsQuincenal()
        {
            return int.Parse(Acuerdo.TipoSueldo.Codigo) == (int)TipoSueldo.QUINCENAL_FIJO 
               || int.Parse(Acuerdo.TipoSueldo.Codigo) == (int)TipoSueldo.QUINCENAL_FIJO_CON_HS_EXTRA;
        }
    }
    public sealed record QuincenaLiquidacion(int Anio, int Mes, int Nro);
    public sealed record EmpleadoLiquidacion(string Dni,
                                             string Cuil,
                                             string Nombre,
                                             string Apellido,
                                             DateTime FechaAlta,
                                             DateTime FechaIngreso);

    public sealed record MontosPagar(decimal EnBlanco, decimal EnNegro);
    public sealed record ItemLiquidacionByIdResponse(string Concepto,
                                                     int Nro,
                                                     int Estado,
                                                     decimal Monto,
                                                     DateTime Fecha,
                                                     bool EsEnBlanco,
                                                     int TipoItem,
                                                     bool EsAutomatico);

    public sealed record PagoLiquidacionById(string Id,
                                            decimal Monto,
                                            string Modo,
                                            DateTime Fecha,
                                            string Descripcion,
                                            string ReferenciaContable);
}
