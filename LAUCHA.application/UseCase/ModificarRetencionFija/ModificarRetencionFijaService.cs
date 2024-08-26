using LAUCHA.application.DTOs.RetencionesFijasDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.ModificarRetencionFija
{
    public class ModificarRetencionFijaService : IModificarRetencionFijaService
    {
        private readonly IGenericRepository<RetencionFija> _RetencionFijaRepository;
        private readonly IGenericRepository<HistorialRetencionFija> _HistorialRepository;
        private readonly ILogsApp log;

        public ModificarRetencionFijaService(IGenericRepository<RetencionFija> retencionFijaRepository,
                                            IGenericRepository<HistorialRetencionFija> historialRepository,
                                            ILogsApp log)
        {
            _RetencionFijaRepository = retencionFijaRepository;
            _HistorialRepository = historialRepository;
            this.log = log;
        }

        public RetencionFijaDTO ModificarRetencionFija(string codigoRetencionFija, ModificadorRetencionFijaDTO modifcaciones)
        {
            log.LogInformation("se va a modificar la retencion fija: {cod}", codigoRetencionFija);

            var retencion = _RetencionFijaRepository.GetById(codigoRetencionFija);

            var registroHistorya = new HistorialRetencionFija
            {
                CodigoRetencionFija = codigoRetencionFija,
                FechaFinVigencia = DateTime.Now,
                Concepto = retencion.Concepto,
                EsPorcentual = retencion.EsPorcentual,
                Unidades = retencion.Unidades
            };

            log.LogInformation("se guarda el registro historico: codigo {cod} , monto: {mont} , porcentual {p}, vigencia: {date}",
                            codigoRetencionFija, registroHistorya.Unidades, registroHistorya.EsPorcentual, registroHistorya.FechaFinVigencia);

            _HistorialRepository.Insert(registroHistorya);

            retencion.Unidades = modifcaciones.Unidades;
            retencion.EsPorcentual = modifcaciones.EsPorcentual;
            retencion.EsQuincenal = modifcaciones.EsQuicenal;

            RetencionFija retencionActualizada = _RetencionFijaRepository.Update(retencion);

            log.LogInformation("se actualizo la retencion fija: cod: {c}, monto: {m}, esQuincenal: {q}",
                                retencion.CodigoRetencionFija, retencion.Unidades, retencion.EsQuincenal);

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
