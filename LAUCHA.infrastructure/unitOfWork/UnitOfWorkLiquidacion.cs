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
        private readonly LiquidacionesDbContext _context;


        public UnitOfWorkLiquidacion(IGenericRepository<Remuneracion> remuneracionRepository,
                                     IGenericRepository<Retencion> retencionRepository,
                                     LiquidacionesDbContext context)
        {
            RemuneracionRepository = remuneracionRepository;
            RetencionRepository = retencionRepository;
            _context = context;
        }


        public int Save()
        => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
