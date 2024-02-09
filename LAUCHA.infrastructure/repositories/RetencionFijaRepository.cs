﻿using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.infrastructure.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.repositories
{
    public class RetencionFijaRepository : IGenericRepository<RetencionFija>
    {
        private readonly LiquidacionesDbContext _context;

        public RetencionFijaRepository(LiquidacionesDbContext context)
        {
            _context = context;
        }

        public RetencionFija Delete(string id)
        {   
            // TODO: deben eliminarse y pasar a historial
            throw new NotImplementedException();
        }

        public IList<RetencionFija> GetAll()
        {
           return _context.RetencionesFijas.ToList();
        }

        public RetencionFija GetById(string codigoRetencionFija)
        {
            RetencionFija? retencionFijaEncontrada = _context.RetencionesFijas.Find(codigoRetencionFija);
            return retencionFijaEncontrada != null ? retencionFijaEncontrada : throw new NullReferenceException();
        }

        public RetencionFija Insert(RetencionFija nuevaRetencionFija)
        {
            _context.Add(nuevaRetencionFija);
            _context.SaveChanges();
            return nuevaRetencionFija;
        }

        public RetencionFija Update(RetencionFija entity)
        {   
            //TODO: implementar para crear el historial
            throw new NotImplementedException();
        }
    }
}