using FluentValidation;

namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    internal class CrearAcuerdoValidator : AbstractValidator<CrearAcuerdoRequest>
    {
        public CrearAcuerdoValidator()
        {
            RuleFor(x => x.Dni).NotEmpty();
            RuleFor(x => x.TipoSueldo).NotEmpty();
            RuleFor(x => x.ValorBlanco > 0);
            RuleFor(x => x.Sueldo > 0);
            RuleFor(x => x.Sueldo > 0);
        }
    }
}
