using FluentValidation;
using LAUCHA.application.Common.Errors;
using LAUCHA.application.Common.Extensions;
using LAUCHA.application.Common.ResultResponse;
using LAUCHA.domain.Entities.Empleados;

namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    internal class CrearEmpleadoHandler : ICrearEmpleado
    {
        private readonly IEmpleadoRepository _empleados;
        private readonly IFabricaEmpleado _fabricaEmpleados;
        private readonly IValidator<CrearEmpleadoRequest> _validator;

        public CrearEmpleadoHandler(IEmpleadoRepository empleados,
                                    IValidator<CrearEmpleadoRequest> validator,
                                    IFabricaEmpleado fabricaEmpleados)
        {
            _empleados = empleados;
            _validator = validator;
            _fabricaEmpleados = fabricaEmpleados;
        }

        public async Task<Result<CrearEmpleadoResponse>> Crear(CrearEmpleadoRequest req)
        {
            var validacion = ValidarEmpleado(req);
            
            if(validacion.IsFailure)
                return Result.Failure<CrearEmpleadoResponse>(validacion.Error);

            var emp =  _fabricaEmpleados.Crear(req);

            try
            {
                await _empleados.Insert(emp);
            }
            catch (Exception)
            {
                return Result.Failure<CrearEmpleadoResponse>(EmpleadoErrors.Guardar);
            }

            return Result.Success(new CrearEmpleadoResponse(emp.Dni, emp.Nombre, emp.Apellido));
        }

        private Result ValidarEmpleado(CrearEmpleadoRequest req)
        {
            var validador = _validator.Validate(req);

            if (!validador.IsValid)
            {
                return Result.Failure(new Error(validador.ToMessageString()));
            }

            return Result.Success(); ;
        }

    }
}
