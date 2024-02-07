using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.ContratosDeTrabajo
{
    public class CrearContratoService
    {
        private readonly IUnitOfWorkContrato _unitOfWork;

        public CrearContratoService(IUnitOfWorkContrato unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ContratoDTO CrearNuevoContrato(CrearContratoDTO nuevoContrato)
        {
            Contrato contratoCreado = AgregarContrato(nuevoContrato);
            string codigoContrato = contratoCreado.CodigoContrato;

            AgregarAcuerdoBlanco(nuevoContrato,codigoContrato);
            AgregarModalidad(nuevoContrato, codigoContrato);
            
            bool existenAdicionales = nuevoContrato.Adicionales.Count() > 0;

            if (existenAdicionales)
            {
                AgregarAdicionales(nuevoContrato, codigoContrato);
            }

            //confirmar el contrato
            _unitOfWork.Save();

            return new ContratoDTO
            {
                
            }
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
                FechaContrato = fechaActual
            };

            return _unitOfWork.ContratoRepository.Insert(contrato);
        }

        private void AgregarAcuerdoBlanco(CrearContratoDTO nuevoContrato,string codigoContrato)
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

            _unitOfWork.AcuerdoBlancoRepository.Insert(acuerdoBlanco);
        }

        private void AgregarModalidad(CrearContratoDTO nuevoContrato, string codigoContrato)
        {
            ModalidadPorContrato modalidadDelContrato = new ModalidadPorContrato
            {
                CodigoModalidad = nuevoContrato.Modalidad,
                CodigoContrato = codigoContrato
            };

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
