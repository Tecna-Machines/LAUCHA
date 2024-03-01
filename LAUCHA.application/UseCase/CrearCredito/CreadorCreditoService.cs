using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.interfaces.IUnitsOfWork;

namespace LAUCHA.application.UseCase.CrearCredito
{
    public class CreadorCreditoService : ICreadorCreditos
    {
        private readonly IUnitOfWorkCredito _UnitOfWorkCredito;

        public CreadorCreditoService(IUnitOfWorkCredito unitOfWorkCredito)
        {
            _UnitOfWorkCredito = unitOfWorkCredito;
        }

        public CreditoDTO CrearNuevoCredito(CrearCreditoDTO nuevoCredito)
        {
            //TODO: crear logica para crear creditos
            throw new NotImplementedException();

            /* recuerde usar el metodo Save(); de la unidad de trabajo
            SIEMPRE al finalizar la creacion de las cuotas y subcuotas (si existen) */
        }
    }
}
