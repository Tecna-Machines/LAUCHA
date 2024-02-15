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
    public class AdicionalPorContratoRepository : IGenericRepository<AdicionalPorContrato> , IAdicionalesPorContratoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public AdicionalPorContratoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public AdicionalPorContrato Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<AdicionalPorContrato> GetAll()
        {
            return _context.AdicionalesPorContrato.ToList();
        }

        public AdicionalPorContrato GetById(string CodigoContrato)
        {
            AdicionalPorContrato? adicionalPorContrato = _context.AdicionalesPorContrato.
                                  FirstOrDefault(ac => ac.CodigoContrato == CodigoContrato);

            return adicionalPorContrato != null ? adicionalPorContrato : throw new NullReferenceException();
        }

        public AdicionalPorContrato Insert(AdicionalPorContrato nuevoAdicionalContrato)
        {
            _context.Add(nuevoAdicionalContrato);
            return nuevoAdicionalContrato;
        }

        public List<AdicionalPorContrato> ObtenerAdicionalesSegunContrato(string codigoContrato)
        {
            return _context.AdicionalesPorContrato.Where(ac => ac.CodigoContrato == codigoContrato).ToList();
        }

        public AdicionalPorContrato Update(AdicionalPorContrato entity)
        {   
            // TODO: es probable que no se necesite
            throw new NotImplementedException();
        }

        public int Save() => _context.SaveChanges();

    }
}
