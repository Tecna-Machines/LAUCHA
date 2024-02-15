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
    public class DescuentoRepository : IGenericRepository<Descuento>
    {
        private readonly LiquidacionesDbContext _context;

        public DescuentoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Descuento Delete(string codigoDescuento)
        {
            Descuento? encontrado = _context.Descuentos.Find(codigoDescuento);

            if(encontrado != null)
            {
                _context.Remove(encontrado);
                return encontrado;
            }
             
            throw new NullReferenceException();
        }

        public IList<Descuento> GetAll()
        {
            return _context.Descuentos.ToList();
        }

        public Descuento GetById(string codigoDescuento)
        {
            Descuento? descuentoEncontrado = _context.Descuentos.Find(codigoDescuento);
            return descuentoEncontrado != null ? descuentoEncontrado : throw new NullReferenceException();
        }

        public Descuento Insert(Descuento descuento)
        {
            _context.Add(descuento);
            return descuento;
        }

        public Descuento Update(Descuento entity)
        {   
            // TODO: podria no ser necesario
            throw new NotImplementedException();
        }
        public int Save() => _context.SaveChanges();

    }
}
