using FluentValidation;
using LAUCHA.application.Common.Errors;
using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Common.ResultResponse;
using LAUCHA.application.Features.Empleados;
using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.Entities.Liquidaciones;

namespace LAUCHA.application.Features.Liquidaciones.CrearLiquidacion
{
    internal class CrearLiquidacionHandler : ICrearLiquidacion
    {
        private readonly IEmpleadoRepository _empleados;
        private readonly ILiquidacionRepository _liquidaciones;
        private readonly IValidator<CrearLiquidacionRequest> _validator;


        public CrearLiquidacionHandler(IEmpleadoRepository empleados,
                                       ILiquidacionRepository liquidaciones,
                                       IValidator<CrearLiquidacionRequest> validator)
        {
            _empleados = empleados;
            _liquidaciones = liquidaciones;
            _validator = validator;
        }

        public async Task<Result<CrearLiquidacionResponse>> Crear(CrearLiquidacionRequest req)
        {
            var validacion = ValidarSolicitud(req);

            if (validacion.IsFailure)
                return Result.Failure<CrearLiquidacionResponse>(validacion.Error);


            var empleadoResult = await ObtenerEmpleado(req.Dni);
            if (empleadoResult.IsFailure)
                return Result.Failure<CrearLiquidacionResponse>(EmpleadoErrors.Obtener);

            var empleado = empleadoResult.Value;

            var liquidacion = Liquidacion.IniciarLiquidacion(
                    empleado,
                    req.Anio,
                    req.Mes,
                    req.Quincena
                );

            var existe = await ExisteLiquidacion(liquidacion.Codigo);
            if (existe)
                return Result.Failure<CrearLiquidacionResponse>(LiquidacionErrors.Existente);

            await _liquidaciones.Insert(liquidacion);

            return Result.Success(new CrearLiquidacionResponse(liquidacion.Codigo));
        }

        private Result ValidarSolicitud(CrearLiquidacionRequest req)
        {
            var validador = _validator.Validate(req);

            if (!validador.IsValid)
            {
                return Result.Failure(new Error(validador.ToMessageString()));
            }

            return Result.Success(); ;
        }

        private async Task<Result<Empleado>> ObtenerEmpleado(string dni)
        {
            var empleado = await _empleados.GetByDni(dni);

            if (empleado is null)
                return Result.Failure<Empleado>(EmpleadoErrors.Obtener);

            return Result.Success(empleado);
        }

        private async Task<bool> ExisteLiquidacion(string codigoLiquidacion)
        {
            var liq = await _liquidaciones.GetById(codigoLiquidacion);
            return liq is not null;
        }

    }
}
