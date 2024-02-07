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
    public class CuentaRepository : IGenericRepository<Cuenta>
    {
        private readonly LiquidacionesDbContext _context;

        public CuentaRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Cuenta Delete(string id)
        {
            // TODO: se debe implementar
            throw new NotImplementedException();
        }

        public IList<Cuenta> GetAll()
        {
            return _context.Cuentas.ToList();
        }

        public Cuenta GetById(string numeroCuenta)
        {
            Cuenta? cuentaEncontrado = _context.Cuentas.Find(numeroCuenta);
            return cuentaEncontrado != null ? cuentaEncontrado : throw new NullReferenceException();
        }

        public Cuenta Insert(Cuenta nuevaCuenta)
        {
            _context.Add(nuevaCuenta);
            return nuevaCuenta;
        }

        public Cuenta Update(Cuenta entity)
        {   
            // TODO: se debe implementar
            throw new NotImplementedException();
        }
    }
}
