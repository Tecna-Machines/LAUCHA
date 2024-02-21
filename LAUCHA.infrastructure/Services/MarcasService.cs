using LAUCHA.domain.interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.Services
{
    public class MarcasService : IMarcasService
    {
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
