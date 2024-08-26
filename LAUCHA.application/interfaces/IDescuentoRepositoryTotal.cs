using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.interfaces
{
    public interface IDescuentoRepositoryTotal : IDescuentoRepository, IGenericRepository<Descuento>
    {
    }
}
