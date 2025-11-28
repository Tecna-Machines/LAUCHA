using LAUCHA.application.Mappers;
using LAUCHA.domain.entities.Contrato;


namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    internal class CrearAcuerdoHandler : ICrearAcuerdo
    {
        private readonly IAcuerdoRepository _acuerdos;
        private readonly ICatalogoRetencionRepository _retenciones;
        private readonly IValidator<CrearAcuerdoRequest> _validator;

        public CrearAcuerdoHandler(IAcuerdoRepository acuerdos,
                                   IValidator<CrearAcuerdoRequest> validator,
                                   ICatalogoRetencionRepository retenciones)
        {
            _acuerdos = acuerdos;
            _validator = validator;
            _retenciones = retenciones;
        }

        public async Task<Result<CrearAcuerdoResponse>> Crear(CrearAcuerdoRequest req)
        {
            var validacion = ValidarAcuerdo(req);

            if (validacion.IsFailure)
                return Result.Failure<CrearAcuerdoResponse>(validacion.Error);

            var acuerdo = await CrearAcuerdo(req);

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

        private async Task<Acuerdo> CrearAcuerdo(CrearAcuerdoRequest req)
        {
            Acuerdo acuerdo = Acuerdo.Crear(req.Dni,
                                            req.Sueldo,
                                            req.ValorBlanco,
                                            req.ValorHora,
                                            TipoSueldoMapper.ToTipoSueldo(req.TipoSueldo));

            acuerdo.AgregarNota(req.Notas);

            AgregarAdicionales(acuerdo, req);
            await AgregarRetenciones(acuerdo, req);

            return acuerdo;
        }

        private void AgregarAdicionales(Acuerdo acuerdo, CrearAcuerdoRequest req)
        {
            int numeroAdicional = 0;

            foreach (var adicional in req.Adicionales)
            {
                var adi = new Adicional
                {
                    Codigo = $"{acuerdo.Codigo}:{numeroAdicional}",
                    CodigoAcuerdo = acuerdo.Codigo,
                    Concepto = adicional.Concepto,
                    FechaCreacion = DateTime.Now,
                    EsEnBlanco = adicional.EsEnBlanco,
                    EsPorcentual = adicional.EsPorcentual,
                    Monto = adicional.Monto
                };

                acuerdo.AgregarAdicional(adi);
                numeroAdicional++;
            }
        }

        private async Task AgregarRetenciones(Acuerdo acuerdo, CrearAcuerdoRequest req)
        {
            foreach (var codigoRetencion in req.Retenciones)
            {
                var retencion = await _retenciones.GetRetencion(codigoRetencion);

                if (retencion is null)
                    throw new ArgumentException("retencion.inexistente");

                acuerdo.AgregarRetencion(retencion);
            }
        }


    }
}
