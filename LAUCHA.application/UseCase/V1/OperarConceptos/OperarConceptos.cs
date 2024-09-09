using LAUCHA.application.DTOs.ConceptoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.V1.OperarConceptos
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
            List<Concepto> conceptos = _ConceptoRepositoy.GetAll().ToList();
            List<ConceptoDTO> retConceptosDto = new List<ConceptoDTO>();
            foreach (Concepto c in conceptos)
            {
                retConceptosDto.Add(new ConceptoDTO { Nombre = c.NombreConcepto, Numero = c.NumeroConcepto });
            }
            return retConceptosDto;
        }

        public ConceptoDTO ConsultarUnConcepto(int numeroConcepto)
        {
            Concepto retConcepto = _ConceptoRepositoy.GetById(numeroConcepto.ToString());
            return new ConceptoDTO { Nombre = retConcepto.NombreConcepto, Numero = retConcepto.NumeroConcepto };
        }

        public ConceptoDTO CrearUnConcepto(ConceptoDTO nuevoConcepto)
        {
            _ConceptoRepositoy.Insert(new Concepto { NombreConcepto = nuevoConcepto.Nombre, NumeroConcepto = nuevoConcepto.Numero });
            _ConceptoRepositoy.Save();
            return nuevoConcepto;
        }
    }
}
