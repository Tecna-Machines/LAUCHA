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
            //TODO: crear logica para crear creditos
            throw new NotImplementedException();

            /* recuerde usar el metodo Save(); del repositorio par guardar todo en la BBDD */
        }
    }
}
