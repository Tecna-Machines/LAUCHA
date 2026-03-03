using LAUCHA.domain.Entities.Feriados;

namespace LAUCHA.infrastructure.asistencias.Repository
{
    internal class FeriadoRepository : IFeriadoRepository
    {
        public Task<ICollection<Feriado>> GetFeriadosDelAnio(int anio)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Feriado>> GetFeriadosDelMes(int mes, int anio)
        {
            throw new NotImplementedException();
        }

        public async Task<Feriado> Insert(Feriado f)
        {
            return f;
        }
    }
}
