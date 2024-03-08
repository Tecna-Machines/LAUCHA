using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.infrastructure.repositories
{
    public class CreditoRepository : IGenericRepository<Credito>
    {
        //TODO: complete el repositorio , no olvide inyectar el context utilizando el constructor , use los demas repositorios como ejemplo 
        public Credito Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Credito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Credito GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Credito Insert(Credito entity)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Credito Update(Credito entity)
        {
            throw new NotImplementedException();
        }
    }
}
