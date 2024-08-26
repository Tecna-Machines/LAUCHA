using LAUCHA.domain.interfaces.IServices;

namespace LAUCHA.infrastructure.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly string _connectionString;

        public MarcasService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public HorasPeriodo ConsularHorasPeriodo(string dni, DateTime desde, DateTime hasta)
        {


            return new HorasPeriodo
            {
                HorasTotales = 20,
                HorasExtraTotales = 3
            };
        }
    }
}
