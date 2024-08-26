using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.CrearRemuneracionNueva
{
    public class CrearRemuneracionNuevaService : ICrearRemuneracionService
    {
        private readonly IGenericRepository<Remuneracion> _RemuneracionRepository;
        private GeneradorDeNumeroAleatorio _GeneradorNumeros;
        private readonly ILogsApp log;

        public CrearRemuneracionNuevaService(IGenericRepository<Remuneracion> remuneracionRepository, ILogsApp log)
        {
            _RemuneracionRepository = remuneracionRepository;
            _GeneradorNumeros = new();
            this.log = log;
        }

        public RemuneracionDTO CrearNuevaRemuneracion(CrearRemuneracionDTO nuevaRemuneracion)
        {
            log.LogInformation("se solicito la creacion de una remuneracion");
            log.LogInformation("cuenta: {c} ,monto: {m}, descripcion: {d}, es blanco: {b}",
                nuevaRemuneracion.Cuenta, nuevaRemuneracion.Monto, nuevaRemuneracion.Descripcion, nuevaRemuneracion.EsBlanco);

            DateTime FechaActual = DateTime.Now;
            int numeroRandom = _GeneradorNumeros.GenerarAleatorioEntreValores(FechaActual.Day, 100);
            string codigoRemuneracion = $"{nuevaRemuneracion.Cuenta}{FechaActual.Minute}{FechaActual.Second}{numeroRandom}";

            Remuneracion remuneracion = new()
            {
                CodigoRemuneracion = codigoRemuneracion,
                Descripcion = nuevaRemuneracion.Descripcion,
                NumeroCuenta = nuevaRemuneracion.Cuenta,
                EsBlanco = nuevaRemuneracion.EsBlanco,
                Monto = nuevaRemuneracion.Monto,
                Fecha = FechaActual
            };

            log.LogInformation("se creo la remuneracion con codigo: {c}", remuneracion.CodigoRemuneracion);

            // guardar la remuneracion en la BBDD
            _RemuneracionRepository.Insert(remuneracion);

            log.LogInformation("se guardo la nueva remuneracion");

            //obtener la remuneracion de la BBDD
            remuneracion = _RemuneracionRepository.GetById(codigoRemuneracion);

            log.LogInformation("recuperando informacion de la remuneraicon: {cod}", codigoRemuneracion);

            return new RemuneracionDTO
            {
                Codigo = remuneracion.CodigoRemuneracion,
                Descripcion = remuneracion.Descripcion,
                Cuenta = remuneracion.NumeroCuenta,
                EsBlanco = remuneracion.EsBlanco,
                Fecha = remuneracion.Fecha.ToString("dd/MM/yyyy HH:mm"),
                Monto = remuneracion.Monto
            };
        }
    }
}
