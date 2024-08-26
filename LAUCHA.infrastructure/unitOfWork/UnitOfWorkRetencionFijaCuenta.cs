﻿using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;

namespace LAUCHA.infrastructure.unitOfWork
{
    public class UnitOfWorkRetencionFijaCuenta : IUnitOfWorkRetencionFijaCuenta, IDisposable
    {
        public IGenericRepository<RetencionFijaPorCuenta> RetencionFijaRepository { get; }
        private readonly LiquidacionesDbContext _context;

        public UnitOfWorkRetencionFijaCuenta(IGenericRepository<RetencionFijaPorCuenta> retencionFijaRepository,
                                            LiquidacionesDbContext context)
        {
            RetencionFijaRepository = retencionFijaRepository;
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
