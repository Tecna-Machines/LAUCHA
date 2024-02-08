using LAUCHA.application.DTOs.CuentaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IAgregarCuentaService
    {
        CuentaDTO AgregarRetencionesFijas(string numeroCuenta, string[] codigosRetenciones);
        CuentaDTO ConsularUnaCuenta(string numeroCuenta);
    }
}
