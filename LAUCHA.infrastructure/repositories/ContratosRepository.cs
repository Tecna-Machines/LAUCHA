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
    public class ContratosRepository : IGenericRepository<Contrato> , IContratoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public ContratosRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public List<Contrato> ObtenerContratosDeEmpleado(string dniEmpleado)
        {
            return _context.Contratos.Where(c => c.DniEmpleado == dniEmpleado).ToList();
        }

        public Contrato Delete(string id)
        {   
            // TODO: checar si es necesario
            throw new NotImplementedException();
        }

        public IList<Contrato> GetAll()
        {
            return _context.Contratos.ToList();

        }

        public Contrato GetById(string codigoContrato)
        {
            Contrato? contratoEncontrado = _context.Contratos.Find(codigoContrato);
            return contratoEncontrado != null ? contratoEncontrado : throw new NullReferenceException();
        }

        public Contrato Insert(Contrato contratoNuevo)
        {
            _context.Add(contratoNuevo);
            return contratoNuevo;
        }

        public Contrato ObtenerContratoDeEmpleado(string dniEmpleado)
        {
            Contrato? ultimoContratoEmpleado = _context.Contratos.Where(c => c.DniEmpleado == dniEmpleado)
                                               .OrderByDescending(c => c.FechaContrato).FirstOrDefault();

            return ultimoContratoEmpleado != null ? ultimoContratoEmpleado : throw new NullReferenceException();
        }

        public Contrato Update(Contrato entity)
        {   
            // TODO: quizas no sea necesario
            throw new NotImplementedException();
        }
    }
}
