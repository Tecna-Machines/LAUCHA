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
    public class RetencionRepository : IGenericRepository<Retencion>
    {
        private readonly LiquidacionesDbContext _context;

        public RetencionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Retencion Delete(string codigoRetencion)
        {
            throw new NotImplementedException();
        }

        public IList<Retencion> GetAll()
        {
           return _context.Retenciones.ToList();
        }

        public Retencion GetById(string codigoRetencion)
        {
            Retencion? encontrada = _context.Retenciones.Find(codigoRetencion);
            return encontrada != null ? encontrada : throw new NullReferenceException();
        }

        public Retencion Insert(Retencion nuevaRetencion)
        {
            _context.Add(nuevaRetencion);
            return nuevaRetencion;
        } 

        public Retencion Update(Retencion entity)
        {
            // TODO: quizas no sea necesario
            throw new NotImplementedException();
        }
        public int Save() => _context.SaveChanges();

    }
}
