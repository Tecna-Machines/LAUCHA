﻿using LAUCHA.application.DTOs.NoRemuneracionDTOs;
using LAUCHA.application.DTOs.PaginaDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.OperarNoRemuneraciones
{
    public class OperarNoRemuneraciones : IOperarNoRemuneracionesService
    {
        private readonly IGenericRepository<NoRemuneracion> _NoRemuneracionRepository;
        private readonly INoRemuneracionRepository _NoRemuneracionRepositoryEspecifico;
        private readonly NoRemuneracionMapper _NoRemuneracionMapper;
        private readonly ILogsApp log;
        public OperarNoRemuneraciones(IGenericRepository<NoRemuneracion> noRemuneracionRepository,
                                      INoRemuneracionRepository noRemuneracionRepositoryEspecifico,
                                      ILogsApp log)
        {
            _NoRemuneracionRepository = noRemuneracionRepository;
            _NoRemuneracionRepositoryEspecifico = noRemuneracionRepositoryEspecifico;
            _NoRemuneracionMapper = new();
            this.log = log;
        }

        public async Task<PaginaDTO<NoRemuneracionDTO>> ConsultarNoRemuneraciones(string? cuenta,
                                                                            DateTime? desde,
                                                                            DateTime? hasta,
                                                                            string? orden,
                                                                            string? descripcion,
                                                                            int index,
                                                                            int cantidadRegistros)
        {

            PaginaRegistro<NoRemuneracion> pagina = await _NoRemuneracionRepositoryEspecifico.
                                                     ObtenerNoRemuneracionesFiltradas(cuenta, desde,
                                                                                      hasta, orden,
                                                                                      descripcion, index,
                                                                                      cantidadRegistros);

            List<NoRemuneracionDTO> noRemuneracionesDTOs = new();
            List<NoRemuneracion> noRemuneracionPagina = pagina.Registros;

            foreach (var noRemu in noRemuneracionPagina)
            {
                NoRemuneracionDTO noRemuDTO = _NoRemuneracionMapper.GenerarDtoNoRemuneracion(noRemu);
                noRemuneracionesDTOs.Add(noRemuDTO);
            }

            return new PaginaDTO<NoRemuneracionDTO>
            {
                Index = pagina.indicePagina,
                TotalEncontrados = pagina.totalRegistros,
                Paginas = pagina.totalPaginas,
                Resultados = noRemuneracionesDTOs
            };
        }

        public NoRemuneracionDTO CosultarUnaNoRemuneracion(string codigoNoRemuneracion)
        {
            NoRemuneracion noRemuneracionEncontrada = _NoRemuneracionRepository.GetById(codigoNoRemuneracion);

            if (noRemuneracionEncontrada != null)
            {
                return _NoRemuneracionMapper.GenerarDtoNoRemuneracion(noRemuneracionEncontrada);
            }

            throw new NullReferenceException();
        }

        public NoRemuneracionDTO CrearNuevaNoRemuneracion(CrearNoRemuneracionDTO nuevaNoRemuneracion)
        {
            log.LogInformation("creando una nueva NO remuneracion , cuenta: {c} ,desc: {d},monto: {m}",
                nuevaNoRemuneracion.Cuenta, nuevaNoRemuneracion.Descripcion, nuevaNoRemuneracion.Monto);

            NoRemuneracion noRemuneracion = _NoRemuneracionMapper.GenerarNoRemuneracion(nuevaNoRemuneracion);

            _NoRemuneracionRepository.Insert(noRemuneracion);
            _NoRemuneracionRepository.Save();

            log.LogInformation("Se creo la NO remuneracion con condigo: {c}", noRemuneracion.CodigoNoRemuneracion);
            return _NoRemuneracionMapper.GenerarDtoNoRemuneracion(noRemuneracion);
        }
    }
}