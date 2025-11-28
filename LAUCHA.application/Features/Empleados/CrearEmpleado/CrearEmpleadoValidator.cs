namespace LAUCHA.application.Features.Empleados.CrearEmpleado
{
    internal class CrearEmpleadoValidator : AbstractValidator<CrearEmpleadoRequest>
    {
        public CrearEmpleadoValidator()
        {
            RuleFor(e => e.Dni).NotEmpty().MinimumLength(5);
            RuleFor(e => e.Nombre).MinimumLength(4);
            RuleFor(e => e.Apellido).MinimumLength(4);
            RuleFor(e => e.FechaNacimiento).LessThan(e => e.FechaIngreso);
            RuleFor(e => e.FechaAlta).GreaterThan(e => e.FechaNacimiento);
        }
    }
}
