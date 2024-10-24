﻿using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ModificarRetencionFija
{
    public class ModificarRetencionFijaService : IModificarRetencionFijaService
    {
        private readonly IGenericRepository<RetencionFija> _RetencionFijaRepository;
        private readonly IGenericRepository<HistorialRetencionFija> _HistorialRepository;

        public ModificarRetencionFijaService(IGenericRepository<RetencionFija> retencionFijaRepository,
                                            IGenericRepository<HistorialRetencionFija> historialRepository)
        {
            _RetencionFijaRepository = retencionFijaRepository;
            _HistorialRepository = historialRepository;
        }

        public RetencionFijaDTO ModificarRetencionFija(string codigoRetencionFija, ModificadorRetencionFijaDTO modifcaciones)
        {
            var retencion = _RetencionFijaRepository.GetById(codigoRetencionFija);

            var registroHistorya = new HistorialRetencionFija
            {
                CodigoRetencionFija = codigoRetencionFija,
                FechaFinVigencia = DateTime.Now,
                Concepto = retencion.Concepto,
                EsPorcentual = retencion.EsPorcentual,
                Unidades = retencion.Unidades
            };

            _HistorialRepository.Insert(registroHistorya);

            retencion.Unidades = modifcaciones.Unidades;
            retencion.EsPorcentual = modifcaciones.EsPorcentual;
            retencion.EsQuincenal = modifcaciones.EsQuicenal;

            RetencionFija retencionActualizada = _RetencionFijaRepository.Update(retencion);

            _RetencionFijaRepository.Save();
            _HistorialRepository.Save();

            return new RetencionFijaDTO
            {
                Codigo = retencionActualizada.CodigoRetencionFija,
                Concepto = retencionActualizada.Concepto,
                EsPorcentual = retencionActualizada.EsPorcentual,
                Unidades = retencionActualizada.Unidades,
                EsQuincenal = retencionActualizada.EsQuincenal
            };

        }
    }
}
