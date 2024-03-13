using LAUCHA.domain.interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly string _connectionString;

        public MarcasService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public HorasPeriodo ConsularHorasPeriodo(string dni,DateTime desde, DateTime hasta)
        {

                return new HorasPeriodo
                {
                    HorasTotales = 18,
                    HorasExtraTotales = 2
                };
        }
    }
}
