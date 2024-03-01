using LAUCHA.application.DTOs.ConceptoDTOs;

namespace LAUCHA.application.interfaces
{
    public interface IOperarConceptosService
    {
        ConceptoDTO ConsultarUnConcepto(int numeroConcepto);
        List<ConceptoDTO> ConsultarTodosLosConceptos();
        ConceptoDTO CrearUnConcepto(ConceptoDTO nuevoConcepto);
    }
}
