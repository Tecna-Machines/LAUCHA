namespace LAUCHA.domain.Entities.Asistencias
{
    public interface IAsistenciasSource
    {
        Task<IEnumerable<Asistencia>> GetByDniYPeriodo(string dni, DateTime inicio, DateTime fin);
        Task<IEnumerable<Asistencia>> GetByPeriodo(DateTime inicio, DateTime fin);
        Task<Asistencia> Insert(Asistencia a);
    }
}
