using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class RetencionPorLiquidacionRepository : IGenericRepository<RetencionPorLiquidacionPersonal>
    {
        private readonly LiquidacionesDbContext _context;

        public RetencionPorLiquidacionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public RetencionPorLiquidacionPersonal Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<RetencionPorLiquidacionPersonal> GetAll()
        {
            return _context.RetencionesPorLiquidaciones.ToList();
        }

        public RetencionPorLiquidacionPersonal GetById(string id)
        {
            throw new NotImplementedException();
        }

        public RetencionPorLiquidacionPersonal Insert(RetencionPorLiquidacionPersonal nueva)
        {
            _context.Add(nueva);
            return nueva;
        }

        public int Save()
            => _context.SaveChanges();

        public RetencionPorLiquidacionPersonal Update(RetencionPorLiquidacionPersonal entity)
        {
            //TODO: tranquilamente no es necesario
            throw new NotImplementedException();
        }
    }
}
