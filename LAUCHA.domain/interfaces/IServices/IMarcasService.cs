using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IServices
{
    public class HorasPeriodo
    {
        public decimal HorasTotales { get; set; }
        public decimal HorasExtraTotales { get; set; }
    }
    public interface IMarcasService
    {
        HorasPeriodo ConsularHorasPeriodo(string dni,DateTime desde,DateTime hasta);
    }
}
