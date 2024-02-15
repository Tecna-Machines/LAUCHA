using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.pagination;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.repositories
{
    public class RemuneracionRepository : IGenericRepository<Remuneracion> , IRemuneracionRepository
    {
        private readonly LiquidacionesDbContext _context;

        public RemuneracionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Remuneracion Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Remuneracion> GetAll()
        {
            return _context.Remuneraciones.ToList();
        }

        public Remuneracion GetById(string codigoRemuneracion)
        {
            Remuneracion? remuneracion = _context.Remuneraciones.Find(codigoRemuneracion);
            return remuneracion != null ? remuneracion : throw new NullReferenceException();
        }

        public Remuneracion Insert(Remuneracion remuneracion)
        {
            _context.Add(remuneracion);
            _context.SaveChanges();
            return remuneracion;
        }

        public async Task<List<Remuneracion>> ObtenerRemuneracionesFiltradas(string numeroCuenta, 
                                                              DateTime? desde, 
                                                              DateTime? hasta, 
                                                              string orden, 
                                                              string descripcion, 
                                                              int indexPagina, 
                                                              int cantidadRegistros)
        {
           var remuneraciones = from r in _context.Remuneraciones select r;

            if(numeroCuenta != null)
            {
                remuneraciones = remuneraciones.Where(r => r.NumeroCuenta == numeroCuenta);
            }

            if(descripcion != null)
            {
                remuneraciones = remuneraciones.Where(r => r.Descripcion.Contains(descripcion));
            }

            if(desde != null)
            {
                remuneraciones = remuneraciones.Where(r => r.Fecha.Date >= desde.Value.Date);
            }

            if(hasta != null)
            {
                remuneraciones = remuneraciones.Where(r => r.Fecha.Date <= hasta.Value.Date);
            }

            if(orden == "DESC")
            {
                remuneraciones = remuneraciones.OrderByDescending(r => r.Fecha);
            }

            return await PaginationGeneric<Remuneracion>.CrearPaginacion(remuneraciones.AsNoTracking(),indexPagina,cantidadRegistros);
        }
        public Remuneracion Update(Remuneracion entity)
        {
            // TODO: esta operacion deberia estar prohibida
            throw new InvalidOperationException();
        }
        public int Save() => _context.SaveChanges();

    }
}
