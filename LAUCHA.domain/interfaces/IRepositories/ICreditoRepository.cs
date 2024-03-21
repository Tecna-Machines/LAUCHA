using LAUCHA.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface ICreditoRepository
    {
        List<Credito> ObtenerCreditosSinPagarDeCuenta(string NumeroCuenta);
        List<Credito> ObtenerTodosCreditosDeCuenta(string NumeroCuenta);
    }
}
