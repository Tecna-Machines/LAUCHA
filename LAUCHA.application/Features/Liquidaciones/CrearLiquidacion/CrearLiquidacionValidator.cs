using FluentValidation;

namespace LAUCHA.application.Features.Liquidaciones.CrearLiquidacion
{
    internal class CrearLiquidacionValidator : AbstractValidator<CrearLiquidacionRequest>
    {
        public CrearLiquidacionValidator()
        {
            RuleFor(cl => cl.Quincena).ExclusiveBetween(1, 2);
            RuleFor(cl => cl.Anio).LessThan(DateTime.Now.Year);
            RuleFor(cl => cl.Dni).NotEmpty();
        }
    }
}
