using LAUCHA.application.DTOs.CreditoDTOs;
using LAUCHA.application.interfaces.V2.Credito;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V2.Credito.GetByEmpleadoId
{
    public class GetCreditosByDni : IGetCreditosByDni
    {
        private readonly ICreditoRepository _creditoRepository;
        private readonly IGenericRepository<Empleado> _empleadoRepository;

        public GetCreditosByDni(ICreditoRepository creditoRepository, IGenericRepository<Empleado> empleadoRepository)
        {
            _creditoRepository = creditoRepository;
            _empleadoRepository = empleadoRepository;
        }

        public List<CreditoDTO> ObtenerCreditosDeUnEmpleado(string dni)
        {
            List<CreditoDTO> creditosMapeados = new();

            var emp = _empleadoRepository.GetById(dni);

            var creditos = _creditoRepository.ObtenerTodosCreditosDeCuenta(emp.Cuenta.NumeroCuenta);

            CreditoMapper mapper = new();

            foreach (var credito in creditos)
            {
                var aux = mapper.GenerarCreditoDTO(credito);
                creditosMapeados.Add(aux);
            }

            return creditosMapeados;
        }
    }
}
