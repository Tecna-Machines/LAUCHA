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
    public class PagoCreditoRepository : IGenericRepository<PagoCredito>
    {
        private readonly LiquidacionesDbContext _context;
        public PagoCreditoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }
        public PagoCredito Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<PagoCredito> GetAll()
        {
            throw new NotImplementedException();
        }

        public PagoCredito GetById(string id)
        {
            throw new NotImplementedException();
        }

        public PagoCredito Insert(PagoCredito pagoCredito)
        {
            _context.PagosCreditos.Add(pagoCredito);
            _context.SaveChanges();
            return pagoCredito;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public PagoCredito Update(PagoCredito entity)
        {
            throw new NotImplementedException();
        }
    }
}
