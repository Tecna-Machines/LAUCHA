using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.pagination
{
    internal class PaginationGeneric<T> : List<T>
    {
        public int IndicePagina { get; private set; }
        public int TotalPaginas { get; private set; }

        public PaginationGeneric(List<T> items, int count, int pageIndex, int pageSize)
        {
            IndicePagina = pageIndex;
            TotalPaginas = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool TienePaginPrevia => IndicePagina > 1;

        public bool TieneSiguientePagina => IndicePagina < TotalPaginas;

        public static async Task<PaginationGeneric<T>> CrearPaginacion(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginationGeneric<T>(items, count, pageIndex, pageSize);
        }

    }
}
