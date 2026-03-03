namespace LAUCHA.domain.Entities.Feriados
{
    public interface IFeriadoRepository
    {
        Task<Feriado> Insert(Feriado f);
        Task<ICollection<Feriado>> GetFeriadosDelAnio(int anio);
        Task<ICollection<Feriado>> GetFeriadosDelMes(int mes,int anio);
    }
}
