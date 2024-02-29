using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class NoRemuneracionPorLiquidacionRepository : IGenericRepository<NoRemuneracionPorLiquidacionPersonal>
    {
        private readonly LiquidacionesDbContext _context;

        public NoRemuneracionPorLiquidacionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public NoRemuneracionPorLiquidacionPersonal Delete(string id)
        {
            //TOOO: quizas no deberian poder borrarse ni alterarse
            throw new NotImplementedException();
        }

        public IList<NoRemuneracionPorLiquidacionPersonal> GetAll()
        {
            return _context.NoRemuneracionesPorLiquidaciones.ToList();
        }

        public NoRemuneracionPorLiquidacionPersonal GetById(string codigoNoRemu)
        {
            var found = _context.NoRemuneracionesPorLiquidaciones.Where(nr => nr.CodigoNoRemuneracion == codigoNoRemu)
                        .FirstOrDefault();

            return found ?? throw new NullReferenceException();
        }

        public NoRemuneracionPorLiquidacionPersonal Insert(NoRemuneracionPorLiquidacionPersonal nuevaNoRemuPorLiq)
        {
            _context.Add(nuevaNoRemuPorLiq);
            return nuevaNoRemuPorLiq;
        }

        public int Save()
        => _context.SaveChanges();

        public NoRemuneracionPorLiquidacionPersonal Update(NoRemuneracionPorLiquidacionPersonal entity)
        {
            throw new NotImplementedException();
        }
    }
}
