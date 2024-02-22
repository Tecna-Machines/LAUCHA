using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.repositories
{
    public class RemuneracionPorLiquidacionRepository : IGenericRepository<RemuneracionPorLiquidacionPersonal>
    {
        private readonly LiquidacionesDbContext _context;

        public RemuneracionPorLiquidacionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public RemuneracionPorLiquidacionPersonal Delete(string codigoLiquidacion)
        {
            var found = _context.RemuneracionesPorLiquidaciones.
                         Where(rl => rl.CodigoLiquidacionPersonal == codigoLiquidacion)
                         .FirstOrDefault();

            if (found == null) { throw new NullReferenceException();}
            _context.Remove(found);
            return found;
        }

        public IList<RemuneracionPorLiquidacionPersonal> GetAll()
        {
            return _context.RemuneracionesPorLiquidaciones.ToList();
        }

        public RemuneracionPorLiquidacionPersonal GetById(string codigoLiquidacion)
        {
            //TODO: esta implementacion no tiene mucho sentido!?
            var found = _context.RemuneracionesPorLiquidaciones.
                         Where(rl => rl.CodigoLiquidacionPersonal == codigoLiquidacion)
                         .FirstOrDefault();

            return found != null ?  found : throw new NullReferenceException();
        }

        public RemuneracionPorLiquidacionPersonal Insert(RemuneracionPorLiquidacionPersonal nueva)
        {
            _context.Add(nueva);
            return nueva;
        }

        public int Save()
            => _context.SaveChanges();

        public RemuneracionPorLiquidacionPersonal Update(RemuneracionPorLiquidacionPersonal entity)
        {
            //TODO: quizas algun dia
            throw new NotImplementedException();
        }
    }
}
