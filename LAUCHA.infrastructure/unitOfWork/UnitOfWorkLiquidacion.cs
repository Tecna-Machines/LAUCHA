using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.unitOfWork
{
    public class UnitOfWorkLiquidacion : IUnitOfWorkLiquidacion , IDisposable
    {
        public IGenericRepository<Retencion> RetencionRepository { get; }
        public IGenericRepository<Remuneracion> RemuneracionRepository { get; }
        public IGenericRepository<LiquidacionPersonal> LiquidacionRepository { get; }
        public IGenericRepository<RemuneracionPorLiquidacionPersonal> RemuneracionLiquidacion { get; }
        public IGenericRepository<RetencionPorLiquidacionPersonal> RetencionLiquidacion { get; }
        public IGenericRepository<DescuentoPorLiquidacionPersonal> DescuentoLiquidacion { get; }
        public IGenericRepository<NoRemuneracionPorLiquidacionPersonal> NoRemuneracionLiquidacion { get; }

        private readonly LiquidacionesDbContext _context;


        public UnitOfWorkLiquidacion(IGenericRepository<Remuneracion> remuneracionRepository,
                                     LiquidacionesDbContext context,
                                     IGenericRepository<Retencion> retencionRepository,
                                     IGenericRepository<RemuneracionPorLiquidacionPersonal> remuneracionLiquidacion,
                                     IGenericRepository<RetencionPorLiquidacionPersonal> retencionLiquidacion,
                                     IGenericRepository<DescuentoPorLiquidacionPersonal> descuentoLiquidacion,
                                     IGenericRepository<LiquidacionPersonal> liquidacionRepository,
                                     IGenericRepository<NoRemuneracionPorLiquidacionPersonal> noRemuneracionLiquidacion)
        {
            _context = context;
            RemuneracionRepository = remuneracionRepository;
            RetencionRepository = retencionRepository;
            RemuneracionLiquidacion = remuneracionLiquidacion;
            RetencionLiquidacion = retencionLiquidacion;
            DescuentoLiquidacion = descuentoLiquidacion;
            LiquidacionRepository = liquidacionRepository;
            NoRemuneracionLiquidacion = noRemuneracionLiquidacion;
        }


        public int Save()
        => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
