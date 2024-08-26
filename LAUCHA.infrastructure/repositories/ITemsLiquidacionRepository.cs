using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.repositories
{
    public class ITemsLiquidacionRepository : IItemsLiquidacionRepository
    {
        private readonly LiquidacionesDbContext _context;

        public ITemsLiquidacionRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public List<Descuento> ObtenerDescuentosLiquidacion(string codigoLiquidacion)
        {
            var listaDescuentoPorLiquidacion = _context.DescuentosPorLiquidaciones
                        .Where(d => d.CodigoLiquidacionPersonal == codigoLiquidacion)
                        .ToList();

            List<Descuento> descuentosLiquidacion = new();

            foreach (var desc in listaDescuentoPorLiquidacion)
            {
                var descuentoEncontrado = _context.Descuentos.Find(desc.CodigoDescuento);

                if (descuentoEncontrado != null)
                {
                    descuentosLiquidacion.Add(descuentoEncontrado);
                }
            }

            return descuentosLiquidacion;
        }

        public List<Remuneracion> ObtenerRemuneracionesLiquidacion(string codigoLiquidacion)
        {
            var listaRemuneracionPorLiquidacion = _context.RemuneracionesPorLiquidaciones
                                                .Where(r => r.CodigoLiquidacionPersonal == codigoLiquidacion)
                                                .ToList();

            List<Remuneracion> remuneracionesLiquidacion = new();

            foreach (var remu in listaRemuneracionPorLiquidacion)
            {
                var remuneracionEncontrada = _context.Remuneraciones.Find(remu.CodigoRemuneracion);

                if (remuneracionEncontrada != null)
                {
                    remuneracionesLiquidacion.Add(remuneracionEncontrada);
                }
            }

            return remuneracionesLiquidacion;
        }

        public List<Retencion> ObtenerRetencionesLiquidacion(string codigoLiquidacion)
        {
            var listaRetencionesPorLiquidacion = _context.RetencionesPorLiquidaciones
                                                .Where(rt => rt.CodigoLiquidacionPersonal == codigoLiquidacion)
                                                .ToList();

            List<Retencion> retencionesLiquidacion = new();

            foreach (var reten in listaRetencionesPorLiquidacion)
            {
                var retencionEncontrada = _context.Retenciones.Find(reten.CodigoRetencion);

                if (retencionEncontrada != null)
                {
                    retencionesLiquidacion.Add(retencionEncontrada);
                }
            }

            return retencionesLiquidacion;
        }

        public List<NoRemuneracion> ObtenerNoRemuneracionesLiquidacion(string codigoLiquidacion)
        {
            var listaNoRemuPorLiquidacion = _context.NoRemuneracionesPorLiquidaciones
                                            .Where(noRemuPorLiq =>
                                            noRemuPorLiq.CodigoLiquidacionPersonal == codigoLiquidacion)
                                            .ToList();

            List<NoRemuneracion> noRemuneracionesLiquidacion = new();

            foreach (var noRemu in listaNoRemuPorLiquidacion)
            {
                var noRemuEncontrada = _context.NoRemuneraciones.Find(noRemu.CodigoNoRemuneracion);

                if (noRemuEncontrada != null)
                {
                    noRemuneracionesLiquidacion.Add(noRemuEncontrada);
                }
            }

            return noRemuneracionesLiquidacion;
        }

        public List<PagoLiquidacion> ObtenerPagosLiquidacion(string codigoLiquidacion)
        {
            return _context.PagosLiquidaciones.Where(pl => pl.CodigoLiquidacion == codigoLiquidacion).ToList();
        }
    }
}
