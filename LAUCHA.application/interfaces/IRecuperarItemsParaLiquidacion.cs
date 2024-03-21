using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IRecuperarItemsParaLiquidacion
    {
        Task<List<Remuneracion>> ObtenerRemuneracionesParaLiquidacion(string NumeroCuenta, DateTime inicioPeriodo, DateTime finPeriodo);
        Task<List<Retencion>> ObtenerRetencionesParaLiquidacion(string NumeroCuenta, DateTime inicioPeriodo, DateTime finPeriodo);
        Task<List<Descuento>> ObtenerDescuentosParaLiquidacion(string NumeroCuenta, string dniEmp, DateTime inicioPeriodo, DateTime finPeriodo);
        Task<List<NoRemuneracion>> ObtenerNoRemunerativoParaLiquidacion(string NumeroCuenta, DateTime inicioPeriodo, DateTime finPeriodo);
    }
}
