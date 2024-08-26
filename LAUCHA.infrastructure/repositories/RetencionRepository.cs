using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.pagination;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.repositories
{
    public class RetencionRepository : IGenericRepository<Retencion>, IRetencionRepository
    {
        private readonly LiquidacionesDbContext _context;

        public RetencionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Retencion Delete(string codigoRetencion)
        {
            throw new NotImplementedException();
        }

        public IList<Retencion> GetAll()
        {
            return _context.Retenciones.ToList();
        }

        public Retencion GetById(string codigoRetencion)
        {
            Retencion? encontrada = _context.Retenciones.Find(codigoRetencion);
            return encontrada != null ? encontrada : throw new NullReferenceException();
        }

        public Retencion Insert(Retencion nuevaRetencion)
        {
            _context.Add(nuevaRetencion);
            return nuevaRetencion;
        }

        public Retencion Update(Retencion entity)
        {
            // TODO: quizas no sea necesario
            throw new NotImplementedException();
        }
        public int Save() => _context.SaveChanges();

        public async Task<PaginaRegistro<Retencion>> ObtenerRetencionesFiltradas(string? numeroCuenta,
                                                                 DateTime? desde,
                                                                 DateTime? hasta,
                                                                 string? orden,
                                                                 string? descripcion,
                                                                 int numeroPagina,
                                                                 int cantidadRegistros)
        {
            var retenciones = from ret in _context.Retenciones select ret;

            if (numeroCuenta != null)
            {
                retenciones = retenciones.Where(r => r.NumeroCuenta == numeroCuenta);
            }

            if (descripcion != null)
            {
                retenciones = retenciones.Where(r => r.Descripcion.Contains(descripcion));
            }

            if (desde != null)
            {
                retenciones = retenciones.Where(r => r.Fecha.Date >= desde.Value.Date);
            }

            if (hasta != null)
            {
                retenciones = retenciones.Where(r => r.Fecha.Date <= hasta.Value.Date);
            }

            if (orden == "DESC")
            {
                retenciones = retenciones.OrderByDescending(r => r.Fecha);
            }

            var pagina = await PaginationGeneric<Retencion>.CrearPaginacion(retenciones.AsNoTracking(), numeroPagina, cantidadRegistros);

            return new PaginaRegistro<Retencion>
            {
                indicePagina = pagina.IndicePagina,
                totalPaginas = pagina.TotalPaginas,
                totalRegistros = pagina.TotalRegistros,
                Registros = pagina
            };

        }

        public List<Retencion> ObtenerRetencionesDeLiquidacion(string codigoLiquidacion)
        {
            List<Retencion> retenciones = new();
            var retencionesRecuperadas = _context.RetencionesPorLiquidaciones
                                        .Where(rl => rl.CodigoLiquidacionPersonal == codigoLiquidacion);

            foreach (var retencion in retencionesRecuperadas)
            {
                var retencionEncontrada = _context.Retenciones.Find(retencion.CodigoRetencion);

                if (retencionEncontrada == null) { throw new NullReferenceException(); }

                retenciones.Add(retencionEncontrada);
            }

            return retenciones;
        }
    }
}
