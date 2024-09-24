using LAUCHA.domain.interfaces.IServices;
using LAUCHA.infrastructure.Services.Marcas.Interface;
using Microsoft.EntityFrameworkCore;

namespace LAUCHA.infrastructure.Services.Marcas.Persistence
{
    public class MarcasDb : IMarcasDb
    {
        private readonly MarcasDbContext _context;

        public MarcasDb(MarcasDbContext context)
        {
            _context = context;
        }

        public List<Marca> GetUserMarcas(string dni, DateTime fechaInicio, DateTime fechaFin)
        {
            var marcasMySQL = _context.Marcas.Where(m => m.IdPersonal == dni)
                                              .Where(m => m.Egreso != null)
                                              .Where(m => m.Ingreso >= fechaInicio && m.Egreso <= fechaInicio);


            var marcas = new List<Marca>();

            marcasMySQL.ForEachAsync(my =>
            {
                var aux = new Marca
                {
                    IdPersonal = my.IdPersonal,
                    Egreso = my.Egreso ?? DateTime.MinValue,
                    Ingreso = my.Ingreso ?? DateTime.MinValue,
                    HsTrabajadas = my.HsTrabajadas ?? 0,
                    Area = my.Area ?? "sin area",
                    Minutos = my.Minutos ?? 0,
                    NombreCompleto = my.NombreCompleto,
                    Tarde = my.Tarde.ToString() ?? "-"
                };

                marcas.Add(aux);
            });

            return marcas;
        }


        public List<Marca> GetMarcas(DateTime fechaInicio, DateTime fechaFin)
        {
            var l = _context.Marcas.Where(m => m.Ingreso >= fechaInicio && m.Ingreso <= fechaFin).ToList();
            return null;
        }
    }
}
