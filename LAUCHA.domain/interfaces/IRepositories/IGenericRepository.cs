namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(string id);
        IList<T> GetAll();
        T Insert(T entity);
        T Update(T entity);
        T Delete(string id);
        int Save();
    }
}
