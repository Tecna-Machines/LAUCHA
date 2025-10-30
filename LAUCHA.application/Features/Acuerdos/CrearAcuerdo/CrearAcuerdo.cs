using FluentValidation;
using LAUCHA.application.Common.ResultResponse;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.Features.Acuerdos.CrearAcuerdo
{
    internal class CrearAcuerdo : ICrearAcuerdo
    {
        private readonly IAcuerdoRepository _acuerdos;
        private readonly IValidator<CrearAcuerdoRequest> _validator;

        public CrearAcuerdo(IAcuerdoRepository acuerdos, IValidator<CrearAcuerdoRequest> validator)
        {
            _acuerdos = acuerdos;
            _validator = validator;
        }

        public Task<Result<CrearAcuerdoResponse>> Crear(CrearAcuerdoRequest req)
        {


            throw new NotImplementedException();

        }

   


    }
}
