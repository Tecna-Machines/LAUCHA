using FluentValidation;
using LAUCHA.application.Common.Errors;
using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Common.ResultResponse;
using LAUCHA.domain.entities.Contrato;
using LAUCHA.domain.Entities.Acuerdos;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    internal class CrearAcuerdoHandler : ICrearAcuerdo
    {
        private readonly IAcuerdoRepository _acuerdos;
        private readonly IValidator<CrearAcuerdoRequest> _validator;

        public CrearAcuerdoHandler(IAcuerdoRepository acuerdos, IValidator<CrearAcuerdoRequest> validator)
        {
            _acuerdos = acuerdos;
            _validator = validator;
        }

        public async Task<Result<CrearAcuerdoResponse>> Crear(CrearAcuerdoRequest req)
        {
            var validacion = ValidarAcuerdo(req);

            if (validacion.IsFailure)
                return Result.Failure<CrearAcuerdoResponse>(validacion.Error);

            var acuerdo = CrearAcuerdo(req);

            await _acuerdos.Insert(acuerdo);

            return Result.Success(new CrearAcuerdoResponse(acuerdo.Codigo));

        }

        private Result ValidarAcuerdo(CrearAcuerdoRequest req)
        {
            var validador = _validator.Validate(req);

            if (!validador.IsValid)
            {
                return Result.Failure(new Error(validador.ToMessageString()));
            }

            return Result.Success(); ;
        }

        private Acuerdo CrearAcuerdo(CrearAcuerdoRequest req)
        {
            Acuerdo acuerdo = Acuerdo.Crear(req.Dni,
                                            req.Sueldo,
                                            req.ValorBlanco,
                                            req.ValorHora);

            acuerdo.AgregarNota(req.Notas);

            int numeroAdicional = 0;

            foreach (var adicional in req.Adicionales)
            {
                var adi = new Adicional
                {
                    Codigo = $"{acuerdo.Codigo}:{numeroAdicional}",
                    CodigoContrato = acuerdo.Codigo,
                    Concepto = adicional.Concepto,
                    FechaCreacion = DateTime.Now,
                    EsEnBlanco = adicional.EsEnBlanco,
                    EsPorcentual = adicional.EsPorcentual,
                    Monto = adicional.Monto
                };

                acuerdo.AgregarAdicional(adi);
                numeroAdicional++;
            }
            return acuerdo;
        }



    }
}
