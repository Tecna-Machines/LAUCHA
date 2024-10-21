using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces.V2.Liquidacion;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V2.Liquidacion.Pago
{
    public class PagarLiquidacion  : IPagarLiquidacionService
    {
        private readonly IGenericRepository<PagoLiquidacion> _pagoRepository;

        public PagarLiquidacion(IGenericRepository<PagoLiquidacion> pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }

        public PagoDTO CrearPagoLiquidacion(CrearPagoLiquidacionDTO pago)
        {

            var pagoEntity = new PagoLiquidacion
            {
                CodigoLiquidacion = pago.codigoLiqudiacion,
                Monto = pago.monto,
                Fecha = DateTime.Now,
                CodigoPago = this.GenerarCodigoPago()
            };

            var pagoInsert = _pagoRepository.Insert(pagoEntity);

            return new PagoDTO
            {
                codigo = pagoInsert.CodigoPago,
                Fecha = pagoInsert.Fecha,
                Monto = pagoInsert.Monto
            };
        }

        private int GenerarCodigoPago()
        {
            // Usa la hora actual en ticks
            long ticks = DateTime.Now.Ticks;

            // Usa los ticks como semilla para el Random
            Random randomWithSeed = new Random((int)ticks);
            int randomValue = randomWithSeed.Next(1000, 9999);

            // Combina ambos para formar un código único
            long uniqueNumber = ticks + randomValue;

            // Asegúrate de que se ajuste a un int
            return (int)(uniqueNumber % int.MaxValue);
        }


    }
}
