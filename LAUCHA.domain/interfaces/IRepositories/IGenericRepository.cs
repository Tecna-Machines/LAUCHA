using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(string id);
        IList<T> GetAll();
        T Insert(T entity);
        T Update(T entity);
        T Delete(string id);
    }
}
