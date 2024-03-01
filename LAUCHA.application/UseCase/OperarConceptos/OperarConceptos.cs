using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.OperarConceptos
{
    public class OperarConceptos : IOperarConceptosService
    {
        private readonly IGenericRepository<Concepto> _ConceptoRepositoy;

        public OperarConceptos(IGenericRepository<Concepto> conceptoRepositoy)
        {
            _ConceptoRepositoy = conceptoRepositoy;
        }

        public List<ConceptoDTO> ConsultarTodosLosConceptos()
        {
            //TODO: POR COMPLETAR

            throw new NotImplementedException();
        }

        public ConceptoDTO ConsultarUnConcepto(int numeroConcepto)
        {
            //TODO: POR COMPLETAR
            throw new NotImplementedException();
        }

        public ConceptoDTO CrearUnConcepto(ConceptoDTO nuevoConcepto)
        {
            //TODO: POR COMPLETAR
            throw new NotImplementedException();
        }
    }
}
