using LAUCHA.domain.Entities.Asistencias;
using LAUCHA.infrastructure.asistencias.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.asistencias.Repository
{
    internal class MarcasRepository : IAsistenciasSource
    {
        private readonly MarcasMySqlContext _dbMarcas;

        public MarcasRepository(MarcasMySqlContext dbMarcas)
        {
            _dbMarcas = dbMarcas;
        }

        public async Task<IEnumerable<Asistencia>> GetByDniYPeriodo(string dni, DateTime inicio, DateTime fin)
        {
            // Tratamos inicio/fin como BA local (sin zona)
            inicio = DateTime.SpecifyKind(inicio, DateTimeKind.Unspecified);
            fin = DateTime.SpecifyKind(fin, DateTimeKind.Unspecified);

            var marcas = await _dbMarcas.Asistencias.Where(m => m.Dni == dni)
                .Where(m =>
                    m.Ingreso != null &&
                    m.Ingreso >= inicio &&
                    m.Ingreso <= fin)
                .Select(m =>
                    m.MapToAsistenciaEntity())
                .ToListAsync();

            return marcas;
        }

        public async Task<IEnumerable<Asistencia>> GetByPeriodo(DateTime inicio, DateTime fin)
        {
            inicio = DateTime.SpecifyKind(inicio, DateTimeKind.Unspecified);
            fin = DateTime.SpecifyKind(fin, DateTimeKind.Unspecified);

            var marcas = await _dbMarcas.Asistencias
                .Where(m =>
                    m.Ingreso != null &&
                    m.Ingreso >= inicio &&
                    m.Ingreso <= fin)
                .Select(m =>
                    m.MapToAsistenciaEntity())
                .ToListAsync();

            return marcas;
        }

        public Task<Asistencia> Insert(Asistencia a)
        {
            throw new NotImplementedException();
        }
    }
}
