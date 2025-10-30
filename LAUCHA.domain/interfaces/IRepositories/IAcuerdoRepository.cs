using LAUCHA.domain.Entities.Acuerdos;

namespace LAUCHA.domain.interfaces.IRepositories
{
    public interface IAcuerdoRepository
    {
        Task Insert(Acuerdo acuerdo);
        Task<Acuerdo?> GetActual(string dni);
        Task<ICollection<Acuerdo>> GetHistorial(string dni);
    }
}
