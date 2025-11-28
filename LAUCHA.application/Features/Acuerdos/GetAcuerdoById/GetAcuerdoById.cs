using LAUCHA.application.Common.ResultResponse;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities.Contrato;
using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.application.Features.Acuerdos.GetAcuerdoById
{
    internal class GetAcuerdoById : IGetAcuerdoById
    {
        private readonly IAcuerdoRepository _acuerdos;

        public GetAcuerdoById(IAcuerdoRepository acuerdos)
        {
            _acuerdos = acuerdos;
        }

        public async Task<Result<GetAcuerdoByIdResponse>> GetAcuerdo(GetAcuerdoByIdResquest req)
        {
            var acu = await _acuerdos.GetById(req.Codigo);

            if (acu is null)
                return Result.Failure<GetAcuerdoByIdResponse>(AcuerdosErrors.NoEncontrado);

            return acu is null
            ? Result.Failure<GetAcuerdoByIdResponse>(AcuerdosErrors.NoEncontrado)
            : Result.Success(Map(acu));
        }

        private static GetAcuerdoByIdResponse Map(Acuerdo a) => new(
            Codigo: a.Codigo,
            Fecha: a.Fecha,
            ValorHora: a.ValorHora,
            ValorBlanco: a.ValorBlanco,
            Sueldo: a.Sueldo,
            Notas: a.Notas ?? string.Empty,
            TipoSueldo: Map(a.TipoSueldo),
            Empleado: new(a.Empleado.Dni, $"{a.Empleado.Nombre} {a.Empleado.Apellido}"),
            Adicionales: a.Adicionales.Select(Map).ToList(),
            Retenciones: a.Retenciones.Select(Map).ToList()
        );

        private static AdicionalAcuerdoResponse Map(Adicional x) =>
            new(x.Concepto, x.Monto, x.EsPorcentual, x.EsEnBlanco);

        private static TipoSueldoResponse Map(TipoSueldo t) =>
            new(TipoSueldoMapper.ToInt(t).ToString(), TipoSueldoMapper.ToString(t));

        private static RetencionResponse Map(RetencionAcuerdo r) =>
         new(r.CodigoRetencion, r.Concepto, r.EsPorcentual, r.PrimeraQuincena, r.Unidades);

    }
}
