using LAUCHA.domain.Entities.Asistencias;
using LAUCHA.infrastructure.asistencias.Models;
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
            inicio = DateTime.SpecifyKind(inicio, DateTimeKind.Unspecified);
    fin    = DateTime.SpecifyKind(fin, DateTimeKind.Unspecified);

    // Si "fin" viene como fecha (ej 31/03), lo convertimos a fin exclusivo:
    var finExclusivo = fin.Date.AddDays(1);

    var marcas = await _dbMarcas.Asistencias
        .Where(m => m.Dni == dni)
        .Where(m => m.Ingreso != null &&
                    m.Ingreso >= inicio.Date &&
                    m.Ingreso < finExclusivo)
        .Select(m => m.MapToAsistenciaEntity())
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

        //como no podemos modificar la db externa utilizamos SQL crudo , no es recomendable
        public async Task<Asistencia> Insert(Asistencia a)
        {
            var m = MarcasMySQL.MapToMarcasMySQL(a);

            await _dbMarcas.Database.ExecuteSqlInterpolatedAsync($@"
        INSERT INTO asistencias
        (DNI, NombreCompleto, Ingreso, Egreso, DebeEntrar, Tarde, HsTrabajadas, Minutos, Area)
        VALUES
        ({m.Dni}, {m.NombreCompleto}, {m.Ingreso}, {m.Egreso}, {m.DebeEntrar}, {m.Tarde}, {m.HsTrabajadas}, {m.Minutos}, {m.Area})
        ");

            return a;
        }
    }
}
