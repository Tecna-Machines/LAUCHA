using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.OperarCredito
{
    public class OperarCreditosService : ICreditoService
    {
        /*NOTA: cree el constructor siguiendo las nomenclaturas vigentes , utilice los repositorios que cre necesarios
          si un repositorio posee metodos sin implementar complete la implementacion*/

        //PISTA: considere usar el repositorio ICreditoRepository , sus metodos especiales podrian ser utiles

        private readonly ICreditoRepositoryTotal _CreditoRepository;
        private readonly IDescuentoRepositoryTotal _DescuentoRepository;
        private readonly IGenericRepository<PagoCredito> _pagoCreditoRepository;
        private readonly ILogsApp log;

        CreditoMapper creditoMapper = new CreditoMapper();
        public OperarCreditosService(ICreditoRepositoryTotal creditoRepository,
            IDescuentoRepositoryTotal descuentoRepository,
            IGenericRepository<PagoCredito> pagoCreditoRepository,
            ILogsApp log)
        {
            _CreditoRepository = creditoRepository;
            _DescuentoRepository = descuentoRepository;
            _pagoCreditoRepository = pagoCreditoRepository;
            this.log = log;
        }

        public CreditoDTO ConsularCredito(string codigoCredito)
        {
            //TODO: debe recuperar 1 credito especifco junto con sus pagos
            Credito credito = _CreditoRepository.GetById(codigoCredito);
            
            return creditoMapper.GenerarCreditoDTO(credito);
        }

        public List<CreditoDTO> ConsultarCreditosCuenta(string numeroCuenta)
        {
            /*usando el numero de cuenta debe recuperar TODOS los creditos
             asociados a una cuenta ya sea que esten pagos o no*/

            log.LogInformation("obteniendo los creditos de la cuenta: {num}", numeroCuenta);

            List<Credito> creditos = _CreditoRepository.ObtenerTodosCreditosDeCuenta(numeroCuenta);
            List<CreditoDTO> creditosDTO = new List<CreditoDTO>();
            foreach (Credito c in creditos) 
            {
                creditosDTO.Add(creditoMapper.GenerarCreditoDTO(c));
            }
            return creditosDTO;
        }

        public CreditoDTO PagarUnCreditoManualmente(string codigoCredito, decimal monto)
        {
            log.LogInformation("realizando pago manual del credito n: {cod} , monto a pagar: {m}",codigoCredito,monto);

            CreditoMapper creditoMapper = new CreditoMapper();
            /*debe ser capaz se incorporar un pago a un credito*/
            Credito credito = _CreditoRepository.GetById(codigoCredito);

            log.LogInformation("se recupero el credito n: {num}", credito.CodigoCredito);
            log.LogInformation("la proxima cuota a cobrar valdra: {monto}", credito.MontoCuota());

            credito.cobrarProximaCuotaManual(monto);

            Descuento descuento = _DescuentoRepository.Insert(new Descuento(credito.Cuenta.NumeroCuenta)
            {
                Fecha = DateTime.Now,
                Monto = monto,
                Descripcion = "Descuento sin descripcion"
            }) ;

            log.LogInformation("agregando el descuento del credito con monto: {m}", descuento.Monto);

            _DescuentoRepository.Save();
            PagoCredito pagoCredito = _pagoCreditoRepository.Insert(new PagoCredito
            {
                Descuento = descuento,
                CodigoCredito = codigoCredito,
                Credito = credito,
                Descripcion = "Pago credito sin descripcion",
                FechaPago = DateTime.Now,
                Monto = monto,
            });

            log.LogInformation("Se creo el pago del credito con monto: {m}", pagoCredito.Monto);
            
            credito.PagosCreditos.Add(pagoCredito);
            _pagoCreditoRepository.Save();
            _CreditoRepository.Save();

            return creditoMapper.GenerarCreditoDTO(credito);
        }
    }
}
