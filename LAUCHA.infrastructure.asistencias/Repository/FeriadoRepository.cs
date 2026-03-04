using LAUCHA.domain.Entities.Feriados;
using LAUCHA.infrastructure.asistencias.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.asistencias.Repository
{
    internal class FeriadoRepository : IFeriadoRepository
    {
        private readonly MarcasMySqlContext _dbMarcas;

        public FeriadoRepository(MarcasMySqlContext dbMarcas)
        {
            _dbMarcas = dbMarcas;
        }

        public async Task<ICollection<Feriado>> GetFeriadosDelAnio(int anio)
        {
            return await _dbMarcas.Feriados.Where(f => f.Fecha.Year == anio)
                                                .ToListAsync();
        }

        public async Task<ICollection<Feriado>> GetFeriadosDelMes(int mes, int anio)
        {
            var inicio = new DateTime(anio, mes, 1);
            var fin = inicio.AddMonths(1);

            return await _dbMarcas.Feriados
                .Where(f => f.Fecha >= inicio && f.Fecha < fin)
                .ToListAsync();
        }

        public async Task<Feriado> Insert(Feriado f)
        {
            await _dbMarcas.Feriados.AddAsync(f);
            await _dbMarcas.SaveChangesAsync();

            return f;
        }
    }
}
