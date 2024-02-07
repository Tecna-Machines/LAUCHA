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
    internal class ModalidadPorContratoRepository : IGenericRepository<ModalidadPorContrato>
    {
        private readonly LiquidacionesDbContext _context;

        public ModalidadPorContratoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public ModalidadPorContrato Delete(string codigoContrato)
        {
            ModalidadPorContrato? modalidadContrato = this.GetById(codigoContrato);
            return modalidadContrato != null ? modalidadContrato : throw new NullReferenceException();
        }

        public IList<ModalidadPorContrato> GetAll()
        {
            return _context.ModalidadesPorContrato.ToList();
        }

        public ModalidadPorContrato GetById(string codigoContrato)
        {
            ModalidadPorContrato? modalidadContrato = _context.ModalidadesPorContrato.
                                                      FirstOrDefault(mc => mc.CodigoContrato == codigoContrato);

            return modalidadContrato != null ? modalidadContrato : throw new NullReferenceException();
        }

        public ModalidadPorContrato Insert(ModalidadPorContrato modalidadPorContrato)
        {
            _context.Add(modalidadPorContrato);
            return modalidadPorContrato;
        }

        public ModalidadPorContrato Update(ModalidadPorContrato entity)
        {   
            // TODO: por implementar pero no parece necesario
            throw new NotImplementedException();
        }
    }
}
