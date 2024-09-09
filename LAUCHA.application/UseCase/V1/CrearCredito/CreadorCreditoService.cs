using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V1.CrearCredito
{
    public class CreadorCreditoService : ICreadorCreditos
    {
        private readonly IGenericRepository<Credito> _CreditoRepository;
        private readonly ILogsApp log;
        public CreadorCreditoService(IGenericRepository<Credito> creditoRepository, ILogsApp log)
        {
            _CreditoRepository = creditoRepository;
            this.log = log;
        }

        public CreditoDTO CrearNuevoCredito(CrearCreditoDTO nuevoCredito)
        {
            log.LogInformation("se esta creando un nuevo credito, cuenta n: ", nuevoCredito.NumeroCuenta);
            log.LogInformation("monto: {m} /cant. de cuotas: {c}", nuevoCredito.Monto, nuevoCredito.CantidadCuotas);

            if (nuevoCredito.CantidadCuotas > 24)
            {
                log.LogWarning("el credito excede las cuotas permitidas");
                throw new NotSupportedException() { };
            }

            string codigoCreditoNuevo = $"CR{nuevoCredito.NumeroCuenta}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}";

            Credito credito = new Credito
            {
                CodigoCredito = codigoCreditoNuevo,
                CantidadCuotasOriginales = nuevoCredito.CantidadCuotas,
                CantidadCuotasFaltantes = nuevoCredito.CantidadCuotas,
                NumeroCuenta = nuevoCredito.NumeroCuenta,
                Monto = nuevoCredito.Monto,
                FechaInicio = nuevoCredito.FechaInicioPago,
                NumeroConcepto = nuevoCredito.NumeroConcepto,
                SePagaQuincenal = nuevoCredito.esQuincenal,
                Descripcion = nuevoCredito.Descripcion
            };

            Credito creditoRet = _CreditoRepository.Insert(credito);

            log.LogInformation("Se creo el credito: {cod}", credito.CodigoCredito);
            log.LogInformation("cant. cuotas originales: ", credito.CantidadCuotasOriginales);
            log.LogInformation("fecha inicio de pago: ", credito.FechaInicio);

            _CreditoRepository.Save();

            log.LogInformation("el credito se guardo exitosamente");

            return new CreditoDTO()
            {
                Codigo = creditoRet.CodigoCredito,
                FechaInicio = creditoRet.FechaInicio,
                Concepto = new ConceptoDTO
                {
                    Nombre = creditoRet.Concepto.NombreConcepto,
                    Numero = creditoRet.Concepto.NumeroConcepto,
                },
                CantidadCuotasFaltantes = creditoRet.CantidadCuotasFaltantes,
                MontoCuota = creditoRet.Monto / creditoRet.CantidadCuotasOriginales,
                MontoFaltante = creditoRet.Monto
            };
        }
    }
}
