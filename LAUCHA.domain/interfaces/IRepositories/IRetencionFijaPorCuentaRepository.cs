using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IRetencionFijaPorCuentaRepository
    {
        List<RetencionFijaPorCuenta> ObtenerRetencionesFijasDeUnaCuenta(string NumeroCuenta);
    }
}
