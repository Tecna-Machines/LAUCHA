using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class HistorialRetencionFijaRepository : IGenericRepository<HistorialRetencionFija>
    {
        private readonly LiquidacionesDbContext _context;

        public HistorialRetencionFijaRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public HistorialRetencionFija Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<HistorialRetencionFija> GetAll()
        {
            return _context.HistorialRetencionesFijas.ToList();
        }

        public HistorialRetencionFija GetById(string id)
        {
            throw new NotImplementedException();
        }

        public HistorialRetencionFija Insert(HistorialRetencionFija historialRetencionFija)
        {
            _context.Add(historialRetencionFija);
            return historialRetencionFija;
        }

        public int Save()
        => _context.SaveChanges();
        public HistorialRetencionFija Update(HistorialRetencionFija entity)
        {
            throw new NotImplementedException();
        }
    }
}
