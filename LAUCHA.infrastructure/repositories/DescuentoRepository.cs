using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.pagination;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.repositories
{
    public class DescuentoRepository : IGenericRepository<Descuento> , IDescuentoRepository
    {
        private readonly LiquidacionesDbContext _context;

        public DescuentoRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public Descuento Delete(string codigoDescuento)
        {
            Descuento? encontrado = _context.Descuentos.Find(codigoDescuento);

            if(encontrado != null)
            {
                _context.Remove(encontrado);
                return encontrado;
            }
             
            throw new NullReferenceException();
        }

        public IList<Descuento> GetAll()
        {
            return _context.Descuentos.ToList();
        }

        public Descuento GetById(string codigoDescuento)
        {
            Descuento? descuentoEncontrado = _context.Descuentos.Find(codigoDescuento);
            return descuentoEncontrado != null ? descuentoEncontrado : throw new NullReferenceException();
        }

        public Descuento Insert(Descuento descuento)
        {
            _context.Add(descuento);
            return descuento;
        }

        public Descuento Update(Descuento entity)
        {   
            // TODO: podria no ser necesario
            throw new NotImplementedException();
        }
        public int Save() => _context.SaveChanges();

        public async Task<PaginaRegistro<Descuento>> ObtenerDescuentosFiltrados(string? numeroCuenta,
                                                                            DateTime? desde,
                                                                            DateTime? hasta,
                                                                            string? orden,
                                                                            string? descripcion,
                                                                            int numeroPagina,
                                                                            int cantidadRegistros)
        {
            var descuentos = from d in _context.Descuentos select d;

            if (numeroCuenta != null)
            {
                descuentos = descuentos.Where(r => r.NumeroCuenta == numeroCuenta);
            }

            if (descripcion != null)
            {
                descuentos = descuentos.Where(r => r.Descripcion.Contains(descripcion));
            }

            if (desde != null)
            {
                descuentos = descuentos.Where(r => r.Fecha.Date >= desde.Value.Date);
            }

            if (hasta != null)
            {
                descuentos = descuentos.Where(r => r.Fecha.Date <= hasta.Value.Date);
            }

            if (orden == "DESC")
            {
                descuentos = descuentos.OrderByDescending(r => r.Fecha);
            }

            var pagina = await PaginationGeneric<Descuento>.CrearPaginacion(descuentos.AsNoTracking(), numeroPagina, cantidadRegistros);

            return new PaginaRegistro<Descuento>
            {
                indicePagina = pagina.IndicePagina,
                totalRegistros = pagina.TotalRegistros,
                totalPaginas = pagina.TotalPaginas,
                Registros = pagina
            };
        }

        public List<Descuento> ObtenerDescuentosDeLiquidacion(string codigoLiquidacion)
        {
            List<Descuento> descuentos = new();

            var descuentosLiquidacion = _context.DescuentosPorLiquidaciones
                                        .Where(dl => dl.CodigoLiquidacionPersonal == codigoLiquidacion)
                                        .ToList();

            foreach (var descuento in descuentosLiquidacion)
            {
                var descuentoEncontrado = _context.Descuentos.Find(descuento.CodigoDescuento);

                if (descuentoEncontrado == null) { throw new NullReferenceException(); }

                descuentos.Add(descuentoEncontrado);
            }

            return descuentos;
        }

    }
}
