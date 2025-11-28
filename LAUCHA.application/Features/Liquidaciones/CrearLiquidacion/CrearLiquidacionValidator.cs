using FluentValidation;

namespace LAUCHA.application.Features.Liquidaciones.CrearLiquidacion
{
    internal class CrearLiquidacionValidator : AbstractValidator<CrearLiquidacionRequest>
    {
        public CrearLiquidacionValidator()
        {
            RuleFor(cl => cl.Quincena).InclusiveBetween(1, 2);
            RuleFor(cl => cl.Anio).LessThan(DateTime.Now.Year + 1);
            RuleFor(cl => cl.Dni).NotEmpty();
        }
    }
}
