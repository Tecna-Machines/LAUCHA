using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.CrearCredito
{
    public class CreadorCreditoService : ICreadorCreditos
    {
        private readonly IGenericRepository<Credito> _CreditoRepository;
        public CreadorCreditoService(IGenericRepository<Credito> creditoRepository)
        {
            _CreditoRepository = creditoRepository;
        }

        public CreditoDTO CrearNuevoCredito(CrearCreditoDTO nuevoCredito)
        {

            if (nuevoCredito.CantidadCuotas > 24) 
            {
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
            _CreditoRepository.Save();

            return new CreditoDTO()
            {
                Codigo = creditoRet.CodigoCredito,
                FechaInicio = creditoRet.FechaInicio,
                Concepto = new ConceptoDTO { 
                    Nombre = creditoRet.Concepto.NombreConcepto, 
                    Numero = creditoRet.Concepto.NumeroConcepto, 
                },
                CantidadCuotasFaltantes = creditoRet.CantidadCuotasFaltantes,
                MontoCuota = creditoRet.Monto  / creditoRet.CantidadCuotasOriginales,
                MontoFaltante = creditoRet.Monto
            };
        }
    }
}
