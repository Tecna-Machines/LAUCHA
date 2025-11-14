using LAUCHA.domain.entities;
using LAUCHA.domain.Entities.Liquidacion;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.pagination;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.repositories
{
    public class LiquidacionPersonalRepository : IGenericRepository<Liquidacion>, ILiquidacionRepository
    {
        private readonly LiquidacionesDbContext _context;

        public LiquidacionPersonalRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public async Task<PaginaRegistro<Liquidacion>> ConseguirLiquidacionesFiltradas(FiltroLiquidacion filtros, int indice, int cantidadRegistros)
        {
            var liquidacionesPersonales = from r in _context.LiquidacionesPersonales select r;

            if (filtros.DniEmp != null)
            {
                string dniEmpleado = filtros.DniEmp;
                liquidacionesPersonales = liquidacionesPersonales
                                .Where(l => l.Codigo.Contains(dniEmpleado));

            }

            if (filtros.FechaLiquidacion != null)
            {
                liquidacionesPersonales = liquidacionesPersonales.Where(l => l.FechaLiquidacion.Date == filtros.FechaLiquidacion.Value.Date);
            }

            if (filtros.InicioPeriodo != null)
            {
                liquidacionesPersonales = liquidacionesPersonales.Where(l => l.InicioPeriodo.Date > filtros.InicioPeriodo.Value.Date);
            }

            if (filtros.FinPeriodo != null)
            {
                liquidacionesPersonales = liquidacionesPersonales.Where(l => l.FinPeriodo.Date < filtros.FinPeriodo.Value.Date);
            }

            if (filtros.CodigoLiquidacionGeneral != null)
            {
                liquidacionesPersonales = liquidacionesPersonales.Where(l => l.CodigoLiquidacionGeneral == filtros.CodigoLiquidacionGeneral);
            }

            if (filtros.Orden)
            {
                liquidacionesPersonales = liquidacionesPersonales.OrderByDescending(l => l.TotalRemuneraciones);
            }

            var pagina = await PaginationGeneric<Liquidacion>
                      .CrearPaginacion(liquidacionesPersonales.AsNoTracking(), indice, cantidadRegistros);

            return new PaginaRegistro<Liquidacion>
            {
                indicePagina = pagina.IndicePagina,
                totalRegistros = pagina.TotalRegistros,
                totalPaginas = pagina.TotalPaginas,
                Registros = pagina
            };
        }

        public Liquidacion Delete(string id)
        {
            //TODO: revisar implementacion de liquidacion repository
            throw new NotImplementedException();
        }

        public IList<Liquidacion> GetAll()
        {
            return _context.LiquidacionesPersonales.ToList();
        }

        public Liquidacion GetById(string codigoLiquidacion)
        {
            var found = _context.LiquidacionesPersonales.Find(codigoLiquidacion);
            return found != null ? found : throw new NullReferenceException();
        }

        public Liquidacion Insert(Liquidacion nuevaLiquidacion)
        {
            _context.Add(nuevaLiquidacion);
            return nuevaLiquidacion;
        }

        public int Save()
        => _context.SaveChanges();

        public Liquidacion Update(Liquidacion liquidacion)
        {
            var origin = _context.LiquidacionesGenerales.FirstOrDefault(l => l.CodigoLiquidacionGeneral == liquidacion.CodigoLiquidacionGeneral);

            if (origin != null)
            {
                _context.Entry(origin).CurrentValues.SetValues(liquidacion);
            }

            return liquidacion;
        }
    }
}
