using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.interfaces;

namespace LAUCHA.application.UseCase.OperarCredito
{
    public class OperarCreditosService : ICreditoService
    {
        /*NOTA: cree el constructor siguiendo las nomenclaturas vigentes , utilice los repositorios que cre necesarios
          si un repositorio posee metodos sin implementar complete la implementacion*/

        //PISTA: considere usar el repositorio ICreditoRepository , sus metodos especiales podrian ser utiles
        public CreditoDTO ConsularCredito(string codigoCredito)
        {
            //TODO: debe recuperar 1 credito especifco junto con sus pagos
            return new CreditoDTO();
        }

        public List<CreditoDTO> ConsultarCreditosCuenta(string numeroCuenta)
        {
            /*usando el numero de cuenta debe recuperar TODOS los creditos
             asociados a una cuenta ya sea que esten pagos o no*/

            return new List<CreditoDTO>();
        }

        public CreditoDTO PagarUnCreditoManualmente(string codigoCredito, decimal monto)
        {
            /*debe ser capaz se incorporar un pago a un credito*/
            return new CreditoDTO();
        }
    }
}
