using LAUCHA.application.Features.Acuerdos.GetAcuerdosEmpleado;
using LAUCHA.domain.Enums;

namespace LAUCHA.application.Mappers
{
    internal class JornadaMapper
    {
        public static JornadaLaboral ToJornadaLabolal(Jornada j)
        {
            if (j == Jornada.COMPLETA)
                return new JornadaLaboral("completa", 9);

            if (j == Jornada.MEDIA)
                return new JornadaLaboral("media", 4);

            throw new InvalidCastException("no es una jornada valida");
        }
    }
}
