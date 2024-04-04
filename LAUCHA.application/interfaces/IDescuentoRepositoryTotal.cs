using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.interfaces
{
    public interface IDescuentoRepositoryTotal: IDescuentoRepository, IGenericRepository<Descuento>
    {
    }
}
