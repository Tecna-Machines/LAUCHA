using LAUCHA.application.DTOs.ContratoDTOs;
using LAUCHA.application.interfaces;
using LAUCHA.domain.Entities.Acuerdos;
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

            Acuerdo contratoCreado = AgregarContrato(nuevoContrato);
            string codigoContrato = contratoCreado.Codigo;

            AgregarAcuerdoBlanco(nuevoContrato, codigoContrato);

            //TODO: fijarse que no tiene adicionales
            bool existenAdicionales = nuevoContrato.Adicionales.Count() > 0;

            //confirmar el contrato
            _unitOfWork.Save();

            log.LogInformation("se realizo con exito la creacion del contrato n: {n}", contratoCreado.Codigo);
            return _contratoTrabajoService.ConsultarContrato(codigoContrato);
        }

        private Acuerdo AgregarContrato(CrearContratoDTO nuevoContrato)
        {
            DateTime fechaActual = DateTime.Now;
            string nuevoCodigoContrato = $"{nuevoContrato.Dni}{fechaActual.Day}{fechaActual.Minute}";

            Acuerdo contrato = new Acuerdo
            {
                Codigo = nuevoCodigoContrato,
                DniEmpleado = nuevoContrato.Dni,
                Sueldo = nuevoContrato.MontoFijo,
                ValorHora = nuevoContrato.MontoHora,
                Fecha = fechaActual,
            };

            log.LogInformation("se agrego el contrato n: {num}", contrato.Codigo);

            //return _unitOfWork.ContratoRepository.Insert(contrato);
            throw new NotImplementedException();
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

    }
}
