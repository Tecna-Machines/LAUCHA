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
    public class LiquidacionPersonalRepository : IGenericRepository<LiquidacionPersonal>
    {
        private readonly LiquidacionesDbContext _context;

        public LiquidacionPersonalRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public LiquidacionPersonal Delete(string id)
        {
            //TODO: revisar implementacion de liquidacion repository
            throw new NotImplementedException();
        }

        public IList<LiquidacionPersonal> GetAll()
        {
            return _context.LiquidacionesPersonales.ToList();
        }

        public LiquidacionPersonal GetById(string codigoLiquidacion)
        {
            var found = _context.LiquidacionesPersonales.Find(codigoLiquidacion);
            return found != null ? found : throw new NullReferenceException();
        }

        public LiquidacionPersonal Insert(LiquidacionPersonal nuevaLiquidacion)
        {
            _context.Add(nuevaLiquidacion);
            return nuevaLiquidacion;
        }

        public int Save()
        => _context.SaveChanges();

        public LiquidacionPersonal Update(LiquidacionPersonal entity)
        {
            throw new NotImplementedException();
        }
    }
}
