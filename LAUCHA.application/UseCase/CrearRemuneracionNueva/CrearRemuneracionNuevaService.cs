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

        public CrearRemuneracionNuevaService(IGenericRepository<Remuneracion> remuneracionRepository)
        {
            _RemuneracionRepository = remuneracionRepository;
            _GeneradorNumeros = new();
        }

        public RemuneracionDTO CrearNuevaRemuneracion(CrearRemuneracionDTO nuevaRemuneracion)
        {
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

            // guardar la remuneracion en la BBDD
            _RemuneracionRepository.Insert(remuneracion);

            //obtener la remuneracion de la BBDD
            remuneracion = _RemuneracionRepository.GetById(codigoRemuneracion);

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
