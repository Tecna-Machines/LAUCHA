using LAUCHA.application.Common.Errors;

namespace LAUCHA.application.Features.Acuerdos
{
    public static class AcuerdosErrors
    {
        public static readonly Error DatoInvalido = new("Acuerdo.Invalido");
        public static readonly Error NoEncontrado = new("Acuerdo.NotFound");
    }
}
