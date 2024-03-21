using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class CreditoRepository : IGenericRepository<Credito>, ICreditoRepository
    {
        private readonly LiquidacionesDbContext _context;
        public CreditoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Credito Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Credito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Credito GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Credito Insert(Credito credito)
        {
            _context.Creditos.Add(credito);
            _context.Entry(credito).Reference(c => c.Concepto).Load();
            return credito;
        }

        public List<Credito> ObtenerCreditosSinPagarDeCuenta(string NumeroCuenta)
        {
            return _context.Creditos.Where(c => c.NumeroCuenta == NumeroCuenta)
                    .Where(c => c.MontoPagado < c.Monto)
                    .ToList();
        }

        public List<Credito> ObtenerTodosCreditosDeCuenta(string NumeroCuenta)
        {
            //TODO: a implementar por NICO
            throw new NotImplementedException();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Credito Update(Credito entity)
        {
            throw new NotImplementedException();
        }
    }
}
