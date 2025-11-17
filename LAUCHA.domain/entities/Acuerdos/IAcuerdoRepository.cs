namespace LAUCHA.domain.Entities.Acuerdos
{
    public interface IAcuerdoRepository
    {
        Task<Acuerdo?> GetById(string id);
        Task Insert(Acuerdo acuerdo);
        Task<Acuerdo?> GetActual(string dni);
        Task<ICollection<Acuerdo>> GetHistorial(string dni);
    }
}
