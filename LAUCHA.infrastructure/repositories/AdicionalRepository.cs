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
    public class AdicionalRepository : IGenericRepository<Adicional>
    {
        private readonly LiquidacionesDbContext _context;

        public AdicionalRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Adicional Delete(string codigoAdicional)
        {
            Adicional? adicionalEncontrado = _context.Adicionales.Find(codigoAdicional);

            if(adicionalEncontrado == null) { throw new NullReferenceException(); }

            _context.Remove(adicionalEncontrado);
            return adicionalEncontrado;
        }

        public IList<Adicional> GetAll()
        {
            return _context.Adicionales.ToList();
        }

        public Adicional GetById(string codigoAdicional)
        {
            Adicional? adicional = _context.Adicionales.Find(codigoAdicional);
            return adicional != null ? adicional : throw new NullReferenceException();
        }

        public Adicional Insert(Adicional nuevoAdicional)
        {
            _context.Add(nuevoAdicional);
            _context.SaveChanges();
            return nuevoAdicional;
        }

        public Adicional Update(Adicional entity)
        {   
            // TODO: plantear actualizar un adicional
            throw new NotImplementedException();
        }
    }
}
