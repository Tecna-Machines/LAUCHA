using LAUCHA.application.DTOs.DescuentoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;

namespace LAUCHA.application.UseCase.OperacionesDescuento
{
    public class OperarDescuentosService : IOperarDescuentosService
    {
        private readonly IGenericRepository<Descuento> _DescuentoRepository;
        private readonly IGenericRepository<Concepto> _ConceptoRepository;
        private readonly DescuentoMapper _DescuentoMapper;
        public OperarDescuentosService(IGenericRepository<Descuento> descuentoRepository, IGenericRepository<Concepto> conceptoRepository)
        {
            _DescuentoRepository = descuentoRepository;
            _DescuentoMapper = new();
            _ConceptoRepository = conceptoRepository;
        }

        public DescuentoDTO CrearUnDescuentoNuevo(CrearDescuentoDTO nuevoDescuentoDTO)
        {
            Descuento nuevo = _DescuentoMapper.CrearDescuento(nuevoDescuentoDTO);
            Concepto? concepto = null;

            _DescuentoRepository.Insert(nuevo);
            _DescuentoRepository.Save();

            if (nuevoDescuentoDTO.NumeroConcepto != null)
            {
                string codigo = nuevoDescuentoDTO.NumeroConcepto.ToString();

                concepto = _ConceptoRepository.GetById(codigo);
            }

            return _DescuentoMapper.CrearDescuentoDTO(nuevo, concepto);
        }
    }
}
