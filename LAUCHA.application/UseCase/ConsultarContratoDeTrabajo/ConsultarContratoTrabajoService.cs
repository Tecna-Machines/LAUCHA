using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.ConsultarContratoDeTrabajo
{
    public class ConsultarContratoTrabajoService
    {
        private readonly IGenericRepository<Empleado> _EmpleadoRepository;
        private readonly IGenericRepository<Contrato> _ContratoRepository;
        private readonly IGenericRepository<ModalidadPorContrato> _ModalidadPorContratoRepository;
        private readonly IGenericRepository<Modalidad> _ModalidadRepository;
        private readonly IGenericRepository<Adicional> _AdicionalRepository;
        private readonly IGenericRepository<AcuerdoBlanco> _AcuerdoBlancoRepository;
        private ContratoMapper _ContratoMapper;

        public ConsultarContratoTrabajoService(IGenericRepository<Empleado> empleadoRepository,
                                               IGenericRepository<Contrato> contratoRepository,
                                               IGenericRepository<Modalidad> modalidadRepository,
                                               IGenericRepository<Adicional> adicionalRepository,
                                               IGenericRepository<AcuerdoBlanco> acuerdoBlancoRepository,
                                               IGenericRepository<ModalidadPorContrato> modalidadPorContratoRepository)
        {
            _EmpleadoRepository = empleadoRepository;
            _ContratoRepository = contratoRepository;
            _ModalidadRepository = modalidadRepository;
            _AdicionalRepository = adicionalRepository;
            _AcuerdoBlancoRepository = acuerdoBlancoRepository;
            _ModalidadPorContratoRepository = modalidadPorContratoRepository;
            _ContratoMapper = new ContratoMapper();
        }

        public ContratoDTO ConsultarContrato(string codigoContrato)
        {
            Contrato contratoEncontrado = _ContratoRepository.GetById(codigoContrato);
            ModalidadPorContrato modalidadPorContrato = _ModalidadPorContratoRepository.GetById(codigoContrato);
            Modalidad modalidad = _ModalidadRepository.GetById(modalidadPorContrato.CodigoModalidad);
            Empleado empleado = _EmpleadoRepository.GetById(contratoEncontrado.DniEmpleado);
            AcuerdoBlanco acuerdoBlanco = _AcuerdoBlancoRepository.GetById(codigoContrato);
            //TODO: reemplantar filtrados con repositorios 

            _ContratoMapper.GenerarContrato(contratoEncontrado,modalidad,empleado)

        }
    }
}
