using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IUnitsOfWork;

namespace LAUCHA.application.UseCase.ContratosDeTrabajo
{
    public class CrearContratoService : ICrearContratoService
    {
        private readonly IUnitOfWorkContrato _unitOfWork;
        private readonly IConsultarContratoTrabajoService _contratoTrabajoService;
        private readonly ILogsApp log;

        public CrearContratoService(IUnitOfWorkContrato unitOfWork,
                                    IConsultarContratoTrabajoService contratoTrabajoService,
                                    ILogsApp log)
        {
            _unitOfWork = unitOfWork;
            _contratoTrabajoService = contratoTrabajoService;
            this.log = log;
        }

        public ContratoDTO CrearNuevoContrato(CrearContratoDTO nuevoContrato)
        {
            log.LogInformation("se esta creando un nuevo contrato para empleado: ", nuevoContrato.Dni);

            Contrato contratoCreado = AgregarContrato(nuevoContrato);
            string codigoContrato = contratoCreado.CodigoContrato;

            AgregarAcuerdoBlanco(nuevoContrato, codigoContrato);
            AgregarModalidad(nuevoContrato, codigoContrato);

            bool existenAdicionales = nuevoContrato.Adicionales.Count() > 0;

            if (existenAdicionales)
            {
                log.LogInformation("se estan creando adicionales para el contrato n: {contrato}}"
                                    , contratoCreado.CodigoContrato);
                AgregarAdicionales(nuevoContrato, codigoContrato);
            }

            //confirmar el contrato
            _unitOfWork.Save();

            log.LogInformation("se realizo con exito la creacion del contrato n: {n}", contratoCreado.CodigoContrato);
            return _contratoTrabajoService.ConsultarContrato(codigoContrato);
        }

        private Contrato AgregarContrato(CrearContratoDTO nuevoContrato)
        {
            DateTime fechaActual = DateTime.Now;
            string nuevoCodigoContrato = $"{nuevoContrato.Dni}{fechaActual.Day}{fechaActual.Minute}";

            Contrato contrato = new Contrato
            {
                CodigoContrato = nuevoCodigoContrato,
                DniEmpleado = nuevoContrato.Dni,
                MontoFijo = nuevoContrato.MontoFijo,
                MontoPorHora = nuevoContrato.MontoHora,
                FechaContrato = fechaActual,
                TipoContrato = nuevoContrato.Tipo
            };

            log.LogInformation("se agrego el contrato n: {num}", contrato.CodigoContrato);

            return _unitOfWork.ContratoRepository.Insert(contrato);
        }

        private void AgregarAcuerdoBlanco(CrearContratoDTO nuevoContrato, string codigoContrato)
        {
            string concepto = "ACUERDO BANCO";

            AcuerdoBlanco acuerdoBlanco = new AcuerdoBlanco
            {
                CodigoAcuerdoBlanco = $"{nuevoContrato.Dni}{codigoContrato}",
                Concepto = concepto,
                EsPorcentual = nuevoContrato.AcuerdoBlanco.EsPorcentual,
                Unidades = nuevoContrato.AcuerdoBlanco.Cantidad,
                CodigoContrato = codigoContrato
            };

            log.LogInformation("se esta agrando un acuerdo blanco , contrato n: {n} ,unidades: {u}"
                               , codigoContrato, acuerdoBlanco.Unidades);

            _unitOfWork.AcuerdoBlancoRepository.Insert(acuerdoBlanco);
        }

        private void AgregarModalidad(CrearContratoDTO nuevoContrato, string codigoContrato)
        {
            ModalidadPorContrato modalidadDelContrato = new ModalidadPorContrato
            {
                CodigoModalidad = nuevoContrato.Modalidad,
                CodigoContrato = codigoContrato
            };

            log.LogInformation("se configuro la modalidad: {m}", modalidadDelContrato.CodigoModalidad);
            _unitOfWork.ModalidadPorContratoRepository.Insert(modalidadDelContrato);
        }

        private void AgregarAdicionales(CrearContratoDTO nuevoContrato, string codigoContrato)
        {
            string[] codigosAdicionales = nuevoContrato.Adicionales;

            foreach (var codigo in codigosAdicionales)
            {
                AdicionalPorContrato adicionalDelContrato = new AdicionalPorContrato
                {
                    CodigoAdicional = codigo,
                    CodigoContrato = codigoContrato
                };

                _unitOfWork.AdicionalPorContratoRepositoy.Insert(adicionalDelContrato);
            }
        }
    }
}
