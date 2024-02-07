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
    internal class ModalidadRepository : IGenericRepository<Modalidad>
    {
        private readonly LiquidacionesDbContext _context;

        public ModalidadRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Modalidad Delete(string id)
        {   
            // TODO: por implementar
            throw new NotImplementedException();
        }

        public IList<Modalidad> GetAll()
        {
            return _context.Modalidades.ToList();
        }

        public Modalidad GetById(string codigoModalidad)
        {
            Modalidad? modalidadEncontrada = _context.Modalidades.Find(codigoModalidad);
            return modalidadEncontrada != null ? modalidadEncontrada : throw new NullReferenceException();
        }

        public Modalidad Insert(Modalidad nuevaModalidad)
        {
            _context.Add(nuevaModalidad);
            return nuevaModalidad;
        }

        public Modalidad Update(Modalidad entity)
        {   
            // TODO: por implementar
            throw new NotImplementedException();
        }
    }
}
