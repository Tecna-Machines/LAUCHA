using LAUCHA.domain.entities.diasEspeciales;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class DiaFeriadoRepository : IDiasFeriadosRepository
    {
        private readonly LiquidacionesDbContext _context;

        public DiaFeriadoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public DiaFeriado cargarFeriado(DiaFeriado feriado)
        {
            _context.DiasFeriados.Add(feriado);
            _context.SaveChanges();

            return feriado;
        }

        public List<DiaFeriado> obtenerFeriadosAnio(int anio)
        {
            return _context.DiasFeriados.Where(f => f.FechaFeriado.Equals(anio)).ToList();
        }
    }
}
