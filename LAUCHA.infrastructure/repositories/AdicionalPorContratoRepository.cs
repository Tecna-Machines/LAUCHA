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
    internal class AdicionalPorContratoRepository : IGenericRepository<AdicionalPorContrato>
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

        public AdicionalPorContrato Update(AdicionalPorContrato entity)
        {   
            // TODO: es probable que no se necesite
            throw new NotImplementedException();
        }
    }
}
