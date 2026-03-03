using LAUCHA.domain.Entities.Feriados;
using LAUCHA.infrastructure.asistencias.Persistence;

namespace LAUCHA.infrastructure.asistencias.Repository
{
    internal class FeriadoRepository : IFeriadoRepository
    {
        private readonly MarcasMySqlContext _dbMarcas;

        public FeriadoRepository(MarcasMySqlContext dbMarcas)
        {
            _dbMarcas = dbMarcas;
        }

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
            await _dbMarcas.Feriados.AddAsync(f);
            await _dbMarcas.SaveChangesAsync();

            return f;
        }
    }
}
