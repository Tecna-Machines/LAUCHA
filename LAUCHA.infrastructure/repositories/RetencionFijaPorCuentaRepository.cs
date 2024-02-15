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
    public class RetencionFijaPorCuentaRepository : IGenericRepository<RetencionFijaPorCuenta> , IRetencionFijaPorCuentaRepository
    {
        private readonly LiquidacionesDbContext _context;

        public RetencionFijaPorCuentaRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public RetencionFijaPorCuenta Delete(string id)
        {   
            // TODO: considerar que se pueda borrar
            throw new NotImplementedException();
        }

        public IList<RetencionFijaPorCuenta> GetAll()
        {
            return _context.RetencionesFijasPorCuentas.ToList();
        }

        public RetencionFijaPorCuenta GetById(string id)
        {   
            // TODO: fijas porque key devolver
            throw new NotImplementedException();
        }

        public RetencionFijaPorCuenta Insert(RetencionFijaPorCuenta retencionFijaDeCuenta)
        {
            _context.Add(retencionFijaDeCuenta);
            return retencionFijaDeCuenta;
        }

        public List<RetencionFijaPorCuenta> ObtenerRetencionesFijasDeUnaCuenta(string NumeroCuenta)
        {
            return _context.RetencionesFijasPorCuentas.Where(rfc => rfc.NumeroCuenta == NumeroCuenta).ToList();
        }

        public RetencionFijaPorCuenta Update(RetencionFijaPorCuenta entity)
        {   
            //TODO: no se deberia implementar
            throw new NotImplementedException();
        }
        public int Save() => _context.SaveChanges();

    }
}
