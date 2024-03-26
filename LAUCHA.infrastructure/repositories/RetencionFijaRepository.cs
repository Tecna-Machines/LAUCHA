using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.repositories
{
    public class RetencionFijaRepository : IGenericRepository<RetencionFija>
    {
        private readonly LiquidacionesDbContext _context;

        public RetencionFijaRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public RetencionFija Delete(string id)
        {   
            // TODO: deben eliminarse y pasar a historial
            throw new NotImplementedException();
        }

        public IList<RetencionFija> GetAll()
        {
           return _context.RetencionesFijas.ToList();
        }

        public RetencionFija GetById(string codigoRetencionFija)
        {
            RetencionFija? retencionFijaEncontrada = _context.RetencionesFijas
                            .Include(r => r.HistorialRetencionesFijas) 
                            .FirstOrDefault(r => r.CodigoRetencionFija == codigoRetencionFija);

            if (retencionFijaEncontrada != null)
            {
                return retencionFijaEncontrada;
            }

            throw new NullReferenceException();
        }

        public RetencionFija Insert(RetencionFija nuevaRetencionFija)
        {
            _context.Add(nuevaRetencionFija);
            _context.SaveChanges();
            return nuevaRetencionFija;
        }

        public RetencionFija Update(RetencionFija retencionFija)
        {
            var origin = _context.RetencionesFijas.Find(retencionFija.CodigoRetencionFija);

            if (origin != null)
            {
                _context.Entry(origin).CurrentValues.SetValues(new
                {
                    retencionFija.Unidades,
                    retencionFija.EsPorcentual,
                    retencionFija.EsQuincenal
                });
            }

            return retencionFija;
        }
        public int Save() => _context.SaveChanges();

    }
}
