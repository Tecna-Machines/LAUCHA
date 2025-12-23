namespace LAUCHA.domain.Entities.Creditos
{
    public interface ICreditoRepository
    {
        Task<Credito?> GetById(string id);
        Task<Credito> Insert(Credito credito);
        Task<Credito> Update(Credito credito);
        Task<IEnumerable<Credito>> GetAll();
        Task<IEnumerable<Credito>> GetByEmpleado(string dni);
    }
}
