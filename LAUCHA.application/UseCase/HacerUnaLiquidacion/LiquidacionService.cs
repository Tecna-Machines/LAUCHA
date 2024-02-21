using LAUCHA.application.DTOs.ContratoDTO;
using LAUCHA.application.DTOs.CuentaDTOs;
using LAUCHA.application.DTOs.LiquidacionDTOs;
using LAUCHA.application.DTOs.RemuneracionDTOs;
using LAUCHA.application.DTOs.RetencionDTOs;
using LAUCHA.application.DTOs.SueldosDTOs;
using LAUCHA.application.Helpers;
using LAUCHA.application.interfaces;
using LAUCHA.application.Mappers;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.application.UseCase.HacerUnaLiquidacion
{
    public class LiquidacionService : ILiquidacionService
    {
        private IEstrategiaCalcularSueldo _CalculadoraSueldo = null!;
        private IFabricaCalculadoraSueldo _FabricaCalculadora;

        private readonly IUnitOfWorkLiquidacion _UnitOfWorkLiquidacion;

        private RemuneracionMapper _MapperRemuneracion;
        private RetencionMapper _MapperRetenciones;


        private  ContratoDTO? _Contrato;
        private  CuentaDTO? _Cuenta;

        public LiquidacionService(IFabricaCalculadoraSueldo fabricaCalculadora,IUnitOfWorkLiquidacion unitOfWorkLiquidacion)
        {
            _MapperRemuneracion = new();
            _MapperRetenciones = new();

            _FabricaCalculadora = fabricaCalculadora;
            _UnitOfWorkLiquidacion = unitOfWorkLiquidacion;
        }

        public void SetearEmpleadoALiquidar(ContratoDTO contratoEmp,CuentaDTO cuentaEmp)
        {
            _Contrato = contratoEmp;
            _Cuenta = cuentaEmp;

            int codigoModalidad = int.Parse(_Contrato.Modalidad.Codigo);
            _CalculadoraSueldo = _FabricaCalculadora.CrearCalculadoraSueldo(codigoModalidad);
        }
        public DeduccionDTOs HacerDeduccionesSueldo()
        {
            SueldosBrutosDTO sueldosBrutos = _CalculadoraSueldo.CalcularSueldoBruto(_Contrato);

            decimal sueldoBrutoBlanco = sueldosBrutos.MontoEnBanco;
            decimal sueldoBrutoEfectivo = sueldosBrutos.MontoEnEfectivo;

            Remuneracion blanco = CrearRemuneracion("sueldo bruto formal", sueldoBrutoBlanco, true);
            Remuneracion efectivo = CrearRemuneracion("sueldo bruto informal", sueldoBrutoEfectivo, false);

            var blancoDTO = _MapperRemuneracion.GenerarRemuneracionDTO(blanco);
            var efectivoDTO = _MapperRemuneracion.GenerarRemuneracionDTO(efectivo);

            List<RemuneracionDTO> remuneracionesDTO = new List<RemuneracionDTO>{blancoDTO,efectivoDTO};
            List<RetencionDTO> retencionesDTO = new();

            var retenciones = _CalculadoraSueldo.CalcularRetencionesSueldo(sueldoBrutoBlanco,_Cuenta);

            foreach (var retencionNueva in retenciones)
            {
               Retencion retencion = _UnitOfWorkLiquidacion.RetencionRepository.Insert(retencionNueva);
                var retencionDTO = _MapperRetenciones.GenerarRetencionDTO(retencion);
                retencionesDTO.Add(retencionDTO);
            }

            _UnitOfWorkLiquidacion.Save();

            return new DeduccionDTOs
            {
                Empleado = _Cuenta.Empleado,
                SueldoBruto = sueldosBrutos,
                Remuneraciones = remuneracionesDTO,
                Retenciones = retencionesDTO
            };
        }

        private Remuneracion CrearRemuneracion(string descripcion,decimal monto,bool esBlanco)
        {
            var remuneracionDTO = new RemuneracionDTO
            {
                Cuenta = this._Cuenta.NumeroCuenta,
                Descripcion = descripcion,
                Monto = monto,
                EsBlanco = esBlanco
            };

            var remuneracion = _MapperRemuneracion.GenerarRemuneracion(remuneracionDTO);

           return _UnitOfWorkLiquidacion.RemuneracionRepository.Insert(remuneracion);
        }



    }
}
