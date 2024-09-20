using LAUCHA.domain.interfaces.IServices;
using LAUCHA.infrastructure.Services.Marcas.Interface;

namespace LAUCHA.infrastructure.Services.Marcas.Persistence
{
    public class MarcasDb : IMarcasDb
    {
        private readonly MarcasDbContext _context;

        public MarcasDb(MarcasDbContext context)
        {
            _context = context;
        }

        public List<Marca> GetUserMarcas(string dni, DateTime fechaInicio, DateTime fechaFin)
        {
            var marcasMySQL = _context.Marcas
             .Where(m => m.IdPersonal == dni && m.Ingreso >= fechaInicio && m.Ingreso <= fechaFin)
             .ToList();
        }


        public List<Marca> GetMarcas(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Marcas.Where(m => m.Ingreso >= fechaInicio && m.Ingreso <= fechaFin).ToList();
        }
    }
}
