using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class DescuentosPorLiquidacionesRepository : IGenericRepository<DescuentoPorLiquidacionPersonal>
    {
        private readonly LiquidacionesDbContext _context;

        public DescuentosPorLiquidacionesRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public DescuentoPorLiquidacionPersonal Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<DescuentoPorLiquidacionPersonal> GetAll()
        {
            return _context.DescuentosPorLiquidaciones.ToList();
        }

        public DescuentoPorLiquidacionPersonal GetById(string id)
        {
            throw new NotImplementedException();
        }

        public DescuentoPorLiquidacionPersonal Insert(DescuentoPorLiquidacionPersonal nuevo)
        {
            _context.Add(nuevo);
            return nuevo;
        }

        public int Save()
            => _context.SaveChanges();

        public DescuentoPorLiquidacionPersonal Update(DescuentoPorLiquidacionPersonal entity)
        {
            throw new NotImplementedException();
        }
    }
}
