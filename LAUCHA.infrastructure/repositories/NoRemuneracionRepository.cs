using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.pagination;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.repositories
{
    public class NoRemuneracionRepository : IGenericRepository<NoRemuneracion>, INoRemuneracionRepository
    {
        private readonly LiquidacionesDbContext _context;

        public NoRemuneracionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public NoRemuneracion Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<NoRemuneracion> GetAll()
        {
            return _context.NoRemuneraciones.ToList();
        }

        public NoRemuneracion GetById(string codigoNoRemuneracion)
        {
            var found = _context.NoRemuneraciones.Find(codigoNoRemuneracion);
            return found ?? throw new NullReferenceException();
        }

        public NoRemuneracion Insert(NoRemuneracion nuevaNoRemuneracion)
        {
            _context.Add(nuevaNoRemuneracion);
            return nuevaNoRemuneracion;
        }

        public async Task<PaginaRegistro<NoRemuneracion>> ObtenerNoRemuneracionesFiltradas(string? numeroCuenta,
                                                                                    DateTime? desde,
                                                                                    DateTime? hasta,
                                                                                    string? orden,
                                                                                    string? descripcion,
                                                                                    int numeroPagina,
                                                                                    int cantidadRegistros)
        {
            var Noremuneraciones = from r in _context.NoRemuneraciones select r;

            if (numeroCuenta != null)
            {
                Noremuneraciones = Noremuneraciones.Where(r => r.NumeroCuenta == numeroCuenta);
            }

            if (descripcion != null)
            {
                Noremuneraciones = Noremuneraciones.Where(r => r.Descripcion.Contains(descripcion));
            }

            if (desde != null)
            {
                Noremuneraciones = Noremuneraciones.Where(r => r.Fecha.Date >= desde.Value.Date);
            }

            if (hasta != null)
            {
                Noremuneraciones = Noremuneraciones.Where(r => r.Fecha.Date <= hasta.Value.Date);
            }

            if (orden == "DESC")
            {
                Noremuneraciones = Noremuneraciones.OrderByDescending(r => r.Fecha);
            }

            var pagina = await PaginationGeneric<NoRemuneracion>
                        .CrearPaginacion(Noremuneraciones.AsNoTracking(), numeroPagina, cantidadRegistros);

            return new PaginaRegistro<NoRemuneracion>
            {
                indicePagina = pagina.IndicePagina,
                totalRegistros = pagina.TotalRegistros,
                totalPaginas = pagina.TotalPaginas,
                Registros = pagina
            };
        }

        public int Save()
        => _context.SaveChanges();

        public NoRemuneracion Update(NoRemuneracion entity)
        {
            throw new NotImplementedException();
        }
    }
}
