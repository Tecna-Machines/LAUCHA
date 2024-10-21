using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class PagoLiquidacionRepository : IGenericRepository<PagoLiquidacion>
    {
        private readonly LiquidacionesDbContext _context;

        public PagoLiquidacionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public PagoLiquidacion Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<PagoLiquidacion> GetAll()
        {
            throw new NotImplementedException();
        }

        public PagoLiquidacion GetById(string id)
        {
            throw new NotImplementedException();
        }

        public PagoLiquidacion Insert(PagoLiquidacion entity)
        {
            _context.PagosLiquidaciones.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public PagoLiquidacion Update(PagoLiquidacion entity)
        {
            throw new NotImplementedException();
        }
    }
}
