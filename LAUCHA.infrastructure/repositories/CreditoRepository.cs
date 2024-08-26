using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.repositories
{
    public class CreditoRepository : IGenericRepository<Credito>, ICreditoRepository, ICreditoRepositoryTotal
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

        public Credito GetById(string codigoCredito)
        {
            return _context.Creditos
                .Where(c => c.CodigoCredito == codigoCredito)
                .Include(c => c.PagosCreditos)
                .Include(c => c.Concepto)
                .Include(c => c.Cuenta)
                .First();
            //throw new NotImplementedException();
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
            return _context.Creditos
                .Where(c => c.NumeroCuenta == NumeroCuenta)
                .Include(c => c.PagosCreditos)
                .Include(c => c.Concepto)
                .ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Credito Update(Credito credito)
        {
            var existingCredito = _context.Creditos.FirstOrDefault(c => c.CodigoCredito == credito.CodigoCredito);

            if (existingCredito != null)
            {
                _context.Entry(existingCredito).CurrentValues.SetValues(credito);

            }

            return existingCredito ?? throw new NullReferenceException();
        }
    }
}
