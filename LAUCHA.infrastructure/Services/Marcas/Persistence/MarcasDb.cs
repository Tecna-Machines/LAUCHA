using LAUCHA.domain.interfaces.IServices;
using LAUCHA.infrastructure.Services.Marcas.Interface;

namespace LAUCHA.infrastructure.Services.Marcas.Persistence
{
    internal class MarcasDb : IMarcasDb
    {
        private readonly MarcasDbContext _context;

        public MarcasDb(MarcasDbContext context)
        {
            _context = context;
        }

        public List<Marca> GetUserMarcas(string dni, DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Marcas
                .Where(m => m.Ingreso >= fechaInicio && m.Ingreso <= fechaFin)
                .Where(m => m.IdPersonal == dni)
                .OrderBy(m => m.Ingreso)
                .ToList();
        }

        public List<Marca> GetMarcas(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Marcas.Where(m => m.Ingreso >= fechaInicio && m.Ingreso <= fechaFin).ToList();
        }
    }
}
