using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.pagination;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class RetencionRepository : IGenericRepository<RetencionOLD>, IRetencionCatalogoRepositoryOLD
    {
        private readonly LiquidacionesDbContext _context;

        public RetencionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public RetencionOLD Delete(string codigoRetencion)
        {
            throw new NotImplementedException();
        }

        public IList<RetencionOLD> GetAll()
        {
            return _context.Retenciones.ToList();
        }

        public RetencionOLD GetById(string codigoRetencion)
        {
            RetencionOLD? encontrada = _context.Retenciones.Find(codigoRetencion);
            return encontrada != null ? encontrada : throw new NullReferenceException();
        }

        public RetencionOLD Insert(RetencionOLD nuevaRetencion)
        {
            _context.Add(nuevaRetencion);
            return nuevaRetencion;
        }

        public RetencionOLD Update(RetencionOLD entity)
        {
            // TODO: quizas no sea necesario
            throw new NotImplementedException();
        }
        public int Save() => _context.SaveChanges();

        public async Task<PaginaRegistro<RetencionOLD>> ObtenerRetencionesFiltradas(string? numeroCuenta,
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

            var pagina = await PaginationGeneric<RetencionOLD>.CrearPaginacion(retenciones.AsNoTracking(), numeroPagina, cantidadRegistros);

            return new PaginaRegistro<RetencionOLD>
            {
                indicePagina = pagina.IndicePagina,
                totalPaginas = pagina.TotalPaginas,
                totalRegistros = pagina.TotalRegistros,
                Registros = pagina
            };

        }

        public List<RetencionOLD> ObtenerRetencionesDeLiquidacion(string codigoLiquidacion)
        {
            List<RetencionOLD> retenciones = new();
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
